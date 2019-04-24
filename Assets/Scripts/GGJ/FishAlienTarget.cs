using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAlienTarget : AlienTarget {

	public Animation unityAnimation;
	public Transform movingCenter;

	public override void OnControlled() {
		unityAnimation.Stop();
		animationManager.PauseAnimationByName("Idle");
		base.OnControlled();
	}

	public override Transform GetCenterTransform() {
		return movingCenter;
	}
}
