using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishUnityAnimation : MonoBehaviour {

	public float animationPlayDelay = .35f;
	public Animation unityAnimation;
	public AnimationManager2D fishAnimationManager;
	public Collider collider;

	// Use this for initialization
	void Start () {
		Invoke("AddEvtListener", .2f);
		Invoke("PlayAnimation", animationPlayDelay);
	}
	
	private void AddEvtListener() {
		fishAnimationManager.AddEventListenerTo("Idle", this.gameObject);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void OnLoopingAnimationDone(Animation2D animation2D) {
		Invoke("PlayAnimation", animationPlayDelay);
	}

	private void PlayAnimation() {
		unityAnimation.Play();
	}

	public void EnableCollider() {
		collider.enabled = true;
	}

	public void DisableCollider() {
		collider.enabled = false;
	}
}
