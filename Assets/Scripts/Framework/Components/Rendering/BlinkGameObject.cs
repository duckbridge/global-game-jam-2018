using UnityEngine;
using System.Collections;

public class BlinkGameObject : MonoBehaviour {

	public float blinkTime = .1f;
	public GameObject targetGameObject;

	private int blinkTimesLeft = 1;
	private bool hideOnDone = false;

	// Use this for initialization
	void Awake () {
		if(!targetGameObject) {
			targetGameObject = this.gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BlinkWithTimeout(int times, float newBlinkTime, bool hideOnDone = false) {
		this.hideOnDone = hideOnDone;
		blinkTime = newBlinkTime;
		Blink (times);
	}

	public void Blink(int times = 1) {
		blinkTimesLeft = times;

		CancelInvoke("DoBlink");
		CancelInvoke("Show");

		DoBlink ();
	}

	public void DoBlink() {

		if(!targetGameObject) {
			targetGameObject = this.gameObject;
		}

		targetGameObject.SetActive (false);

		Invoke("Show", blinkTime);
	}

	private void Show() {

		targetGameObject.SetActive (true);

		if (blinkTimesLeft == 1 && hideOnDone) {
			targetGameObject.SetActive (false);
		}

		if(blinkTimesLeft == -1) {
			Invoke ("DoBlink", blinkTime);
		}
		
		if(blinkTimesLeft > 1) {
			Invoke ("DoBlink", blinkTime);
			blinkTimesLeft--;
		}
	}
}
