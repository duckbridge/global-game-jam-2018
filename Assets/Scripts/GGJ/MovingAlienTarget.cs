using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
public class MovingAlienTarget : AlienTarget {

	public Animation2D walkingAnimation;
	public float moveSpeed = 5f;
	public List<Transform> moveTargets;
	private int currentMoveIndex = 0;

	private float originalScaleX;
	
	public override void Start () {
		base.Start();
		originalScaleX = walkingAnimation.transform.localScale.x;
		MoveTo();
	}

	private void MoveTo() {
		if(moveTargets[currentMoveIndex].position.x > this.transform.position.x) {
			walkingAnimation.transform.localScale = new Vector3(
				originalScaleX, 
				walkingAnimation.transform.localScale.y, 
				walkingAnimation.transform.localScale.z);
		} else {
			walkingAnimation.transform.localScale = new Vector3(
				originalScaleX * -1f, 
				walkingAnimation.transform.localScale.y, 
				walkingAnimation.transform.localScale.z);
		}
		iTween.MoveTo(this.gameObject, new ITweenBuilder()
			.SetPosition(moveTargets[currentMoveIndex].position)
			.SetEaseType(iTween.EaseType.linear)
			.SetSpeed(moveSpeed)
			.SetName("Moving")
			.SetOnComplete("MoveToNext")
			.SetOnCompleteTarget(this.gameObject)
			.Build()
		);
	}

	private void MoveToNext() {
		currentMoveIndex++;
		if (currentMoveIndex >= moveTargets.Count) {
			currentMoveIndex = 0;
		}
		MoveTo();
	}

	public override void OnControlled() {
		base.OnControlled();
		iTween.StopByName(this.gameObject, "Moving");
	}
}

