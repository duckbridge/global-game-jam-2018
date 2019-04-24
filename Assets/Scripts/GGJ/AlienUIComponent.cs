using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienUIComponent : MonoBehaviour {

	public AlienTargetType alienTargetType;

	public bool isCollected = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetColor(Color color) {
		GetComponent<SpriteRenderer>().color = color;
	}
}
