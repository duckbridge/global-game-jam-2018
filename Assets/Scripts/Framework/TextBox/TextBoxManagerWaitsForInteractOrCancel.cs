using UnityEngine;
using System.Collections;

public class TextBoxManagerWaitsForInteractOrCancel : TextBoxManager {

	public bool quitOnCancel = true;
	public GameObject stuffToShow;
	private bool isWaitingOnInteract = false;

	public override void Update () {
		base.Update ();

		if(isWaitingOnInteract && !isPaused && !isBusy && isActivated) {
			if(alienInputActions.shoot.WasPressed) {
				stuffToShow.SetActive (false);
				OnTextBoxManagerDone();
			}
		}
	}

	protected override void OnBeforeTextBoxManagerDone() {
		isWaitingOnInteract = true;
		if (stuffToShow) {
			stuffToShow.SetActive (true);	
		}
	}
}
