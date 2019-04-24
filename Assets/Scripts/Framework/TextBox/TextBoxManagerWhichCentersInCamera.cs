using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxManagerWhichCentersInCamera : TextBoxManager {
	public string cameraName = "GameCamera";
	public Vector3 newLocalPosition = new Vector3(0f, 0f, 3f);

	private Transform originalParent;
	private Vector3 originalLocalPosition;

	protected override void OnActivated (int playerIndex) {

		originalParent = this.transform.parent;
		originalLocalPosition = this.transform.localPosition;

		this.transform.parent = GameObject.Find(cameraName).transform;
		this.transform.localPosition = newLocalPosition;

		base.OnActivated (playerIndex);
	}

	private void ResetTextBoxPosition () {
		this.transform.parent = originalParent;
		this.transform.localPosition = originalLocalPosition;
	}

	protected override void OnHideAnimationDone () {
		ResetTextBoxPosition ();
		base.OnHideAnimationDone ();
	}
}
