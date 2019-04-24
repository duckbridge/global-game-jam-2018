using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class ObjectWall : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		AlienBullet alienBullet = other.gameObject.GetComponent<AlienBullet>();
		if (alienBullet) {
			Destroy(alienBullet.gameObject);
			SceneUtils.FindObject<AlienGameManager>().ResetGame();
		}	
	}

}
