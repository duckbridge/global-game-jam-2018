using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {

	public float minimumRespawnTime = 1f;
	public float maximumRespawnTime = 3f;

	public float moveSpeed = 5f;
	public Transform moveTarget;
	private int currentMoveIndex = 0;

	private Vector3 originalPosition;

	private AnimationManager2D animationManager;
	// Use this for initialization
	void Start () {
		animationManager = this.GetComponentInChildren<AnimationManager2D>();
		animationManager.Initialize();

		originalPosition = this.transform.position;

		MoveTo();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void MoveTo() {
		iTween.MoveTo(this.gameObject, new ITweenBuilder()
			.SetPosition(moveTarget.position)
			.SetEaseType(iTween.EaseType.linear)
			.SetSpeed(moveSpeed)
			.SetName("Moving")
			.SetOnComplete("ResetMoving")
			.SetOnCompleteTarget(this.gameObject)
			.Build()
		);
	}

	private void ResetMoving() {
		this.transform.position = originalPosition;
		Invoke("MoveTo", Random.Range(minimumRespawnTime, maximumRespawnTime));
	}

	private void OnTriggerEnter(Collider other) {
		AlienBullet alienBullet = other.gameObject.GetComponent<AlienBullet>();
		if (alienBullet) {
			//Dead
			Destroy(alienBullet.gameObject);
			SceneUtils.FindObject<AlienGameManager>().ResetGame();
		}	
	}
}
