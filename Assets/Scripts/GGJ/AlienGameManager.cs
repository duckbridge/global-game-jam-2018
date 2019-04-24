using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AlienGameManager : MonoBehaviour {

	private SoundObject explodeUnlockedSound;
	private SoundObject enemyHitSound;

	void Start () {
		GameObject.Find("IntroCutscene").GetComponent<CutSceneManager>().StartCutScene(false);
		explodeUnlockedSound = 
			this.transform.Find("Sounds/ExplodeUnlockedSound")
			.GetComponent<SoundObject>();

		enemyHitSound = 
			this.transform.Find("Sounds/EnemyHitSound")
			.GetComponent<SoundObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayExplodeUnlockedSound() {
		explodeUnlockedSound.Play();
	}

	public void PlayEnemyHitSound() {
		enemyHitSound.Play();
	}

	public void OnGameWon() {
		GameObject.Find("OutroCutscene").GetComponent<CutSceneManager>().StartCutScene(false);
	}

	public void ResetGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
