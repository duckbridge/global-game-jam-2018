using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNextSceneDelayed : MonoBehaviour {

	public float delay;
	public Scene sceneToLoad;
	// Use this for initialization
	void Start () {
		Invoke("LoadNextScene", delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void LoadNextScene() {
		SceneManager.LoadScene(sceneToLoad.ToString());
	}
}
