using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererContainer : MonoBehaviour {

	private Transform fromTransform, toTransform;
	private LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (fromTransform != null && toTransform != null) {
			Show();
		}
	}

	public void AttachAndShow(Transform fromTransform, Transform toTransform) {
		this.fromTransform = fromTransform;
		this.toTransform = toTransform;
		Show();
	}

	private void Show() {
		Vector3 positionDiff = fromTransform.localPosition - toTransform.localPosition;
			
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetPosition(0, Vector3.zero);
		lineRenderer.SetPosition(1, positionDiff);
		lineRenderer.enabled = true;
	}
}
