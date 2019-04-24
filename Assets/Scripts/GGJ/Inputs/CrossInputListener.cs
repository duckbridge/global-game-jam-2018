using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CrossInputListener : MonoBehaviour {

	private AlienInputActions alienInputActions;
	private bool isShown = false;
	// Use this for initialization
	void Start () {
		alienInputActions = AlienInputActions.CreateWithDefaultBindings();
	}
	
	// Update is called once per frame
	void Update () {
		if(isShown) {
			if(alienInputActions.shoot.IsPressed) {
				GetComponent<Animation2D>().SetCurrentFrame(1);
			} else {
				GetComponent<Animation2D>().SetCurrentFrame(0);
			}
		}
	}

	public void Show() {
		isShown = true;
		GetComponent<SpriteRenderer>().enabled = true;
	}

	public void Hide() {
		isShown = false;
		GetComponent<SpriteRenderer>().enabled = false;
	}
}
