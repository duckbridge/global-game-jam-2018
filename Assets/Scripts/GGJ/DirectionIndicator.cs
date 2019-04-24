using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour {

	public LineRenderer lineRenderer;

	private Transform aimIndicator;

	private AlienTargetManager alienTargetManager;
	// Use this for initialization
	void Awake () {
		aimIndicator = this.transform.Find("AimIndicator");
		alienTargetManager = SceneUtils.FindObject<AlienTargetManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeDirection(Vector3 aimPosition, Vector3 shootSourcePosition, Vector3 direction) {
		if(alienTargetManager.CanDoInputs()) {
			//aimIndicator.localPosition = new Vector3(aimPosition.x, 1f, aimPosition.y);
			aimIndicator.gameObject.SetActive(false);
			lineRenderer.SetPosition(0, new Vector3(0f, 1f, 0f));
			lineRenderer.SetPosition(1, direction * 10);
		}
	}
}
