using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
public class LeftStickControl : MonoBehaviour {

	private AlienInputActions alienInputActions;
	private List<Vector2> lastPositions = new List<Vector2>();
	private Vector2 direction;
	private Vector2 lastPosition, lastPositionNormalized, 
	lastNoNZeroPosition, lastValidAimDirection;
	private Vector2 currentPosition;

	// Use this for initialization
	void Start () {
		alienInputActions = AlienInputActions.CreateWithDefaultBindings();
	}
	
	// Update is called once per frame
	void Update () {
		currentPosition = alienInputActions.GetLeftAnalogPosition();
		if(IsPulledFurtherThan(currentPosition.normalized, .2f)) {
			lastNoNZeroPosition = currentPosition;
		}
		direction = currentPosition - lastPosition;
		lastPositionNormalized = lastPosition.normalized;
		lastPosition = currentPosition;
	}

	public Vector2 GetNormalizedPosition() {
		return currentPosition.normalized;
	}

	public Vector2 GetLastNormalizedNonZeroPosition() {
		return lastNoNZeroPosition.normalized;
	}

	public Vector2 GetLastNonZeroPosition() {
		return lastNoNZeroPosition;
	}

	public Vector2 GetNormalizedDirection() {
		return lastPositionNormalized * -1f;
	}

	public void ResetPositions() {
		lastPositionNormalized = Vector2.zero;
		lastNoNZeroPosition = Vector2.zero;
		currentPosition = Vector2.zero;
		lastValidAimDirection = Vector2.zero;
	}

	public Vector3 GetAimDirection(bool isNormalized) {
		var lastNonZeroNorm = 
			isNormalized ? GetLastNormalizedNonZeroPosition() : GetLastNonZeroPosition();
		return new Vector3(
			lastNonZeroNorm.x,
			0f,
			lastNonZeroNorm.y
		);
	}

	public Vector2 GetLastPositionNormalized() {
		return lastPositionNormalized;
	}

	public Vector2 GetCurrentPosition() {
		return currentPosition;
	}

	public Vector2 GetDirection() {
		return direction;
	}

	private bool IsZeroPosition(Vector2 pos) {
		return pos.magnitude <= 0.01f;
	}
	
	private bool IsPulledFurtherThan(Vector2 pos, float amount) {
		return pos.magnitude > amount;
	}
}

