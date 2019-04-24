using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTester : MonoBehaviour {

	public RopeContainer ropeContainer;

	public Transform source, target;
	// Use this for initialization
	void Start () {
		ropeContainer.ExtendRope(source, target);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
