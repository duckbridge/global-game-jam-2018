using UnityEngine;
using System.Collections;

public class PlatformerAIAction : DispatchBehaviour {

	public string actionName = "NONE";
	protected bool isActive = false;
	protected bool isPaused = false;

	public virtual void Start () {}
	
	public void Update () {
		if(isActive) {
			OnRegularUpdate();
		}
	}

	public virtual void FixedUpdate() {
		if(isActive && !isPaused) {
			OnUpdate();
		}
	}

	protected virtual void OnUpdate() {
		
	}

	protected virtual void OnRegularUpdate() {
	
	}

	protected virtual void OnActionStarted() {
		
	}
	
	protected virtual void OnActionFinished() {
		
	}
	
	public virtual void OnTriggered(Collider coll) {
		
	}
	
	public virtual void OnCollided(Collision coll) {
		
	}

	public virtual void FinishAction() {
		OnActionFinished();
		this.isActive = false;
	}

	public virtual void StartAction() {
		isActive = true;

		OnActionStarted();
	}

	public virtual void OnSecondStageEntered() {}

	protected void DeActivate(string nextActionName) {
		if(isActive) {
			DispatchMessage("OnActionDone", nextActionName);
		}
	}

	public string GetActionName() {
		return this.actionName;
	}

	public void ResumeAction() {
		isPaused = false;
		OnResume ();
	}

	public void PauseAction() {
		isPaused = true;
		OnPaused ();
	}

	protected virtual void OnResume() {}
	protected virtual void OnPaused() {}

	public bool IsActive() {
		return isActive;
	}
}
