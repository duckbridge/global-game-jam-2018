using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBullet : AlienBullet {
	
	// Update is called once per frame
	public override void Update () {
		base.Update();
		this.transform.localScale = new Vector3(
			this.transform.localScale.x * 0.97f,
			this.transform.localScale.y,
			this.transform.localScale.z * 0.97f
		);
	}
}
