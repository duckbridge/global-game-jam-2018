using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPlanet : MonoBehaviour {

	public Scene sceneToLoad;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		AlienBullet alienBullet = other.gameObject.GetComponent<AlienBullet>();
		if(alienBullet) {
			alienBullet.gameObject.SetActive(false);
			Invoke("LoadNextLevelDelayed", 1f);
		}
	}

	private void LoadNextLevelDelayed() {
		SceneManager.LoadScene(sceneToLoad.ToString());
	}
}
