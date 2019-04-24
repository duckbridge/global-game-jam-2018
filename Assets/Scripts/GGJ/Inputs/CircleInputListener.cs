using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CircleInputListener : MonoBehaviour {

	private AlienInputActions alienInputActions;

	// Use this for initialization
	void Start () {
		alienInputActions = AlienInputActions.CreateWithDefaultBindings();
	}
	
	// Update is called once per frame
	void Update () {
		if(alienInputActions.explode.IsPressed) {
			GetComponent<Animation2D>().SetCurrentFrame(1);
		} else {
			GetComponent<Animation2D>().SetCurrentFrame(0);
		}
	}
}
