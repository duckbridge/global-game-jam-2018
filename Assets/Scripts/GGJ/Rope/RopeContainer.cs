	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;

	public class RopeContainer : DispatchBehaviour {
		public float extendSpeed = 15f;
		public Color[] colors;
		public RopeSegment ropePrefab;

		private float ropeSegDistance = 0.2f;

		private List<RopeSegment> ropeSegments = new List<RopeSegment>();

		private Transform ropeSource, ropeTarget, ropeExtender;
		private Vector3 currentRopeTargetPosition;
		private Vector3 currentRopeSourcePosition;
		private Vector3 currentRopeExtenderPosition;

		private Dictionary<int, int> colorIndexByIndex = new Dictionary<int, int>();

		private bool ropeIsExtending = false;
		private bool ropeCanExtend = true;
		private int maxIndex = 200;

		private Vector3 extensionDirection;
		// Use this for initialization
		public void Awake () {
			ropeExtender = this.transform.Find("RopeExtender");
			for(int i = 0 ; i < maxIndex ;i++) {
				colorIndexByIndex.Add(i, Random.Range(0, colors.Length));
			}
		}
		
		// Update is called once per frame
		void FixedUpdate () {
			if(this.ropeTarget != null && 
				this.ropeSource != null) {
					if(
						this.ropeTarget.position != currentRopeTargetPosition ||
						this.ropeSource.position != currentRopeSourcePosition ||
						(this.ropeExtender.position != currentRopeExtenderPosition && ropeCanExtend)
					) {
						Debug.Log("moved, re-preparing rope");
						PrepareRope(this.ropeSource, this.ropeTarget);
					}
			}

			if(ropeIsExtending) {
				OnExtending();
			}
		}

		public void ExtendRope(Transform ropeSource, Transform ropeTarget) {
			ropeCanExtend = false;
			this.currentRopeTargetPosition = ropeTarget.position;
			this.currentRopeSourcePosition = ropeSource.position;
			this.currentRopeExtenderPosition = ropeSource.position;

			this.ropeSource = ropeSource;
			this.ropeTarget = ropeTarget;
			this.ropeExtender.position = ropeSource.position;
			ropeCanExtend = true;
			ropeIsExtending = true;
		}
		
		private void OnExtending() {
			Vector3 distance = this.ropeTarget.position - this.ropeExtender.position;
			extensionDirection = distance.normalized * extendSpeed;
			this.ropeExtender.position += extensionDirection;
		}

		private void OnExtendingDone() {
			ropeIsExtending = false;
			this.ropeExtender.position = this.ropeTarget.position;
			PrepareRope(this.ropeSource, this.ropeTarget);
			DispatchMessage("OnRopeExtendingDone", null);
		}

		public void PrepareRope(Transform ropeSource, Transform ropeTarget) {
			this.currentRopeTargetPosition = ropeTarget.position;
			this.currentRopeSourcePosition = ropeSource.position;
			this.currentRopeExtenderPosition = ropeExtender.position;

			this.ropeSource = ropeSource;
			this.ropeTarget = ropeTarget;

			Vector3 direction = ropeTarget.position - ropeSource.position;
			float ropeLength = direction.magnitude;
			direction.Normalize();
			ClearRopeParts();
			SpawnRopeParts(ropeLength, ropeSource.position, ropeExtender.position, ropeTarget.position, direction);
		}

		private void ClearRopeParts() {
			ropeCanExtend = true;
			for(int i = 0; i < ropeSegments.Count ; i++) {
				Destroy(ropeSegments[i].gameObject);
			}
			ropeSegments.Clear();
		}

		private void SpawnRopeParts(float ropeLength, Vector3 ropeStart, Vector3 ropeExtension, Vector3 ropeEnd, Vector3 ropeDirection) {
			for(int i = 0 ; i < maxIndex; i++) {

				Vector3 newPosition = ropeStart + ropeDirection * (ropeSegDistance * i);

				if(ropeIsExtending) {
					if(NewPositionIsPastTarget(ropeExtension, ropeEnd, extensionDirection)) {
						Debug.LogWarning("extension is past target");
						OnExtendingDone();
						return;
					}

					if (NewPositionIsPastTarget(newPosition, ropeExtension, ropeDirection)) {
						Debug.Log("new position is past extension limit");
						return;
					}
				} else {
					if (NewPositionIsPastTarget(newPosition, ropeEnd, ropeDirection)) {
						Debug.Log("new position is past rope end!");
						return;
					}
				}

				RopeSegment ropeSegment = GameObject.Instantiate(
					ropePrefab,
					new Vector3(
						this.transform.position.x, 
						this.transform.position.y,
						this.transform.position.z
						),
						Quaternion.identity
					);
				ropeSegment.ropeSprite.color = colors[colorIndexByIndex[i]];
				ropeSegment.transform.parent = this.transform;
				ropeSegment.transform.position = newPosition;

				ropeSegments.Add(ropeSegment);
			}
		}

		private bool NewPositionIsPastTarget(Vector3 newPosition, Vector3 ropeEnd, Vector3 ropeDirection) {
			if(ropeDirection.x > 0) {
				if(ropeDirection.z > 0) {
					return newPosition.x > ropeEnd.x && newPosition.z > ropeEnd.z;
				} else if(ropeDirection.z < 0) {
					return newPosition.x > ropeEnd.x && newPosition.z < ropeEnd.z;
				} else {
					return newPosition.x > ropeEnd.x;
				}
			} else if(ropeDirection.x < 0) {
				if(ropeDirection.z > 0) {
					return newPosition.x < ropeEnd.x && newPosition.z > ropeEnd.z;
				} else if(ropeDirection.z < 0) {
					return newPosition.x < ropeEnd.x && newPosition.z < ropeEnd.z;
				} else {
					return newPosition.x < ropeEnd.x;
				}
			} else {
				if(ropeDirection.z > 0) {
					return newPosition.z > ropeEnd.z;
				} else if(ropeDirection.z < 0) {
					return newPosition.z < ropeEnd.z;
				} else {
					return false;
				}
			}
		}
	}
