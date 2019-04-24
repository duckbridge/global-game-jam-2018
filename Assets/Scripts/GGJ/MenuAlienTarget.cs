using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
public class MenuAlienTarget : AlienTarget {

	private bool isShot =  false;
	public override void OnControlled() {

	}

	public override void OnLostControl() {
		directinIndicator.gameObject.SetActive(false);
		animationManager.StopHideAllAnimations();
	}

	protected override void ResetShooting() {

	}
}

