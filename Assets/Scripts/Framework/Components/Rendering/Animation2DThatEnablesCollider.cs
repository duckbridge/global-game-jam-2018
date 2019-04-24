using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Animation2DThatEnablesCollider : Animation2D {


	public Collider colliderToToggle;
	public List<int> framesToToggleColliderOn;


	public override void OnFrameEntered (int enteredFrame) {
		if(colliderToToggle != null) {
			if(framesToToggleColliderOn.Contains(enteredFrame)) {
				colliderToToggle.enabled = true;
			} else {
				colliderToToggle.enabled = false;
			}
		}
	}
}
