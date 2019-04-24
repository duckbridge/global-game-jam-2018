using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
public class AlienTargetManager : MonoBehaviour {

	public CutSceneManager cutsceneOnExplodeUnlocked;
	public float timeCameraNeedsToShake = 500f;
	public int requiredAliensToHit = 2;
	public AlienTarget currentAlienTarget;
	private List<AlienTarget> alienTargetsVisited = new List<AlienTarget>();
	private List<AlienTarget> alienTargetPath = new List<AlienTarget>();

	private List<AlienTarget> allAlienTargets = new List<AlienTarget>();

	private int targetsHit = 0;

	private AlienInputActions alienInputActions;

	private bool canDoInputs = true;

	private AlienGameManager alienGameManager;

	private bool canExplodeAllEnemies = false;
	private float timeExplodePressed = 0f;

	private CameraShaker cameraShaker;

	private AlienUIManager alienUIManager;

	// Use this for initialization
	void Start () {
		alienUIManager = SceneUtils.FindObject<AlienUIManager>();
		cameraShaker = SceneUtils.FindObject<CameraShaker>();
		alienGameManager = SceneUtils.FindObject<AlienGameManager>();
		alienInputActions = AlienInputActions.CreateWithDefaultBindings();
		alienTargetsVisited.Add(currentAlienTarget);
		alienTargetPath.Add(currentAlienTarget);

		allAlienTargets = SceneUtils.FindObjects<AlienTarget>();
		allAlienTargets.ForEach(alienTarget => alienTarget.AddEventListener(this.gameObject));
	}
	
	public bool HasConnectedAllAliens() {
		return alienTargetPath.Count == allAlienTargets.Count;
	}

	public void BackTrack() {
		if (alienTargetPath.Count > 1) {
			Debug.Log("Backtracking??");
			//do something
			int lastIndex = alienTargetPath.Count - 1;
			currentAlienTarget.OnLostControl();
			currentAlienTarget = alienTargetPath[lastIndex - 1];
			currentAlienTarget.OnControlled();
			alienTargetPath.RemoveAt(lastIndex);
		}
	}

	void Update() {
		if (alienInputActions.reset) {
			SceneUtils.FindObject<AlienGameManager>().ResetGame();
		}
		
		if(canExplodeAllEnemies) {
			if(alienInputActions.explode.IsPressed) {
				timeExplodePressed+=1f;
				cameraShaker.ShakeShakeCamera(
					new Vector3(
						timeExplodePressed/100, 
						timeExplodePressed/100
						),
					true);
				if(timeExplodePressed > timeCameraNeedsToShake) {
					canExplodeAllEnemies = false;
					ExplodeAllEnemies();
				}
			} 
			if(alienInputActions.explode.WasReleased) {
				timeExplodePressed = 0f;
			}
		}
	}

/*
	public void BackTrack(AlienTarget backtrackTarget) {
		this.backtrackTarget = backtrackTarget;
		iTween.MoveTo(this.gameObject,
			new ITweenBuilder()
				.SetPosition(backtrackTarget.transform.position)
				.SetSpeed(3f)
				.SetOnCompleteTarget(this.gameObject)
				.SetOnComplete("OnBacktrackingComplete").Build());
	}

	private void OnBacktrackingComplete() {
		SceneUtils.FindObject<AlienTargetManager>().SwitchAlien(backtrackTarget);
		Destroy(this.gameObject);
	}
 */

	public void OnAlienTargetHit(AlienTarget alienTarget) {
		alienTargetPath.Add(alienTarget);
		alienTargetsVisited.Add(alienTarget);
		currentAlienTarget = alienTarget;

		targetsHit++;
		Debug.Log("hit " + targetsHit + " aliens");
		alienUIManager.OnEnemyHit(alienTarget.alienTargetType);
		if (targetsHit >= requiredAliensToHit) {
			if(!canExplodeAllEnemies) {
				alienGameManager.PlayExplodeUnlockedSound();
				alienUIManager.OnExplodeUnlocked();
				OnCanExplodeEnemies();

			}
			canExplodeAllEnemies = true;
		} else {
			alienGameManager.PlayEnemyHitSound();
		}
	}

	protected virtual void OnCanExplodeEnemies() {
		if(cutsceneOnExplodeUnlocked != null) {
			cutsceneOnExplodeUnlocked.StartCutScene(false);
		}
	}

	public void ExplodeAllEnemies() {
		alienTargetPath = alienTargetPath.FindAll(alien => !alien.isSpaceShip);
		KillAllAliens();
	}

	private void KillAllAliens() {
		if(alienTargetPath.Count > 0) {
			int index = alienTargetPath.Count - 1;
			alienTargetPath[index].Kill();
			alienTargetPath.RemoveAt(index);
			Invoke("KillAllAliens", .2f);
		} else {
			alienGameManager.OnGameWon();
		}
	}

	public void TogglePlayerInput(bool enableInputs) {
		canDoInputs = enableInputs;
	}

	public bool CanDoInputs() {
		return canDoInputs;
	}
}
