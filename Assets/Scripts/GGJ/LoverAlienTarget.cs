using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
public class LoverAlienTarget : AlienTarget {

	public List<LoverAlienTarget> otherLovers;
	public float moveSpeed = 5f;
	public Transform moveTarget;

	private void RunAway() {
		iTween.MoveTo(this.gameObject, new ITweenBuilder()
			.SetPosition(moveTarget.position)
			.SetEaseType(iTween.EaseType.linear)
			.SetSpeed(moveSpeed)
			.SetName("Moving")
			.Build()
		);
		animationManager.PlayAnimationByName("Running");
	}

	public override void OnControlled() {
		base.OnControlled();
		iTween.StopByName(this.gameObject, "Moving");
		otherLovers.ForEach(lover => lover.OnLoverHit());
	}

	public void OnLoverHit() {
		if(!isInfected) {
			RunAway();
		}
	}
}

