using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
public class AlienTarget : DispatchBehaviour {

	public AlienTargetType alienTargetType;
	public bool isSpaceShip = false;
	public RopeContainer ropeContainerPrefab;
	public bool isControlled = false;

	public AlienBullet bulletPrefab;
	public DirectionIndicator directinIndicator;
	private AlienInputActions alienInputActions;

	private List<RopeContainer> ropeContainers = new List<RopeContainer>();

	private bool canDoAction = true;

	private LeftStickControl leftStickControl;

	protected AnimationManager2D animationManager;
	
	private Transform shootPosition;

	private Animation2D[] bloodAnimations;

	private SoundObject explosionSound, flingSound;

	private AlienTargetManager alienTargetManager;

	protected bool isInfected = false;

	// Use this for initialization
	public virtual void Start () {
		alienTargetManager = SceneUtils.FindObject<AlienTargetManager>();
		alienInputActions = AlienInputActions.CreateWithDefaultBindings();
		leftStickControl = SceneUtils.FindObject<LeftStickControl>();
		animationManager = GetComponentInChildren<AnimationManager2D>();

		if(this.transform.Find("Sounds")) {
			if(this.transform.Find("Sounds/ExplosionSound")) {
				explosionSound  = this.transform.Find("Sounds/ExplosionSound").GetComponent<SoundObject>();
			}

			if(this.transform.Find("Sounds/FlingSound")) {
				flingSound  = this.transform.Find("Sounds/FlingSound").GetComponent<SoundObject>();
			}
		}
		if (this.transform.Find("ShootPosition")) {
			shootPosition = this.transform.Find("ShootPosition");
		} else {
			shootPosition = this.transform;
		}

		if(isControlled) {
			OnControlled();
		}

		if(this.transform.Find("BloodAnimations")) {
			bloodAnimations = 
				this.transform.Find("BloodAnimations")
					.GetComponentsInChildren<Animation2D>();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(isControlled && alienTargetManager.CanDoInputs()) {
			var normalizedPosition = leftStickControl.GetNormalizedPosition();
			
			var animationName = DecideAnimationName(normalizedPosition.x * -1f, normalizedPosition.y * -1f);
		
			var aimDirection = leftStickControl.GetAimDirection(false);
			var currentPosition = leftStickControl.GetCurrentPosition();

			var shootAnimationName = DecideAnimationName(aimDirection.x, aimDirection.z);
			Debug.Log("anim " + shootAnimationName);
			if (animationName.Length > 1 && animationManager != null) {
				animationManager.PlayAnimationByName(animationName);
			}

			directinIndicator.ChangeDirection(currentPosition, shootPosition.position, aimDirection);
			

			if(canDoAction) {
				if(alienInputActions.shoot.IsPressed && aimDirection.magnitude > .3f) 
				{
					leftStickControl.ResetPositions();
					canDoAction = false;
					Debug.Log("aim direction " + aimDirection);
					Debug.Log("Aimed in direction " + aimDirection);
					Debug.Log("Will use animation " + shootAnimationName);
					
					if(flingSound != null) {
						flingSound.Play(true);
					}

					if(shootAnimationName != null && animationManager) {
						animationManager.PlayAnimationByName(shootAnimationName);
						animationManager.DisableSwitchAnimations();
					}
					AlienBullet bullet = GameObject.Instantiate(bulletPrefab, shootPosition.position, Quaternion.identity);
					bullet.SetSource(this.gameObject);
					bullet.SetOriginGo(shootPosition.gameObject);
					bullet.Shoot(aimDirection);
					OnLostControl();
					Invoke("ResetShooting", .3f);
				}
			}
		}
	}

	private string DecideAnimationName(float x, float y) {
		float threshold = 0.5f;
		string prefix = "Aiming-";
		if(x < -threshold) {
			if(y > threshold) {
				return prefix + "LeftUp";
			} else if(y < -	threshold) {
				return prefix + "LeftDown";
			} else {
				return prefix + "Left";
			}
		} else if(x > threshold) {
			if(y > threshold) {
				return prefix + "RightUp";
			} else if(y < -threshold) {
				return prefix + "RightDown";
			} else {
				return prefix + "Right";
			}
		} else {
			if(y > threshold) {
				return prefix + "Up";
			} else if(y < -threshold) {
				return prefix + "Down";
			}
			return prefix + "Neutral";
		}
	}
	private bool IsZeroPosition(Vector2 pos) {
		return pos.magnitude <= 0.1f;
	}
	
	private bool IsPulledFurtherThan(Vector2 pos, float amount) {
		return pos.magnitude > amount;
	}

	protected virtual void ResetShooting() {
		if(animationManager != null) {
			animationManager.EnableSwitchAnimations();
			animationManager.PlayAnimationByName("Aiming-Neutral");
		}
		canDoAction = true;
	}

 	void OnTriggerEnter(Collider other) {
		 AlienBullet bullet = other.gameObject.GetComponent<AlienBullet>();
		if (bullet && 
			bullet.GetOriginGo() != this.gameObject &&
			bullet.GetSource() != this.gameObject) 
		{
			Debug.Log("Bullet incoming from other alien");
			//Add check to see if connection already exists.
			SceneUtils.FindObject<AlienTargetManager>().OnAlienTargetHit(this);
			RopeContainer ropeContainer = GameObject.Instantiate(ropeContainerPrefab, GetCenterTransform().position, Quaternion.identity);
			ropeContainer.transform.parent = this.transform;
			ropeContainer.AddEventListener(this.gameObject);

			Transform originTransform = bullet.GetOriginGo().transform;
			if(bullet.GetOriginGo().GetComponent<AlienTarget>()) {
				originTransform = 
				bullet.GetOriginGo().GetComponent<AlienTarget>()
				.GetCenterTransform();
			}
			ropeContainer.PrepareRope(originTransform, GetCenterTransform());
			bullet.BeforeDestroy();
			Destroy(bullet.gameObject);
			PlayInfectionSound();
			OnControlled();
		}
	}

	private void PlayInfectionSound() {
		if(this.transform.Find("Sounds/InfectionSounds")) {
			SoundObject[] sounds = this.transform.Find("Sounds/InfectionSounds")
				.GetComponentsInChildren<SoundObject>();
			sounds[Random.Range(0, sounds.Length)].Play(true);
		}
	}

	public void OnExtendingDone() {

	}

	public virtual void OnLostControl() {
		directinIndicator.gameObject.SetActive(false);
		isControlled = false;
		canDoAction = false;
	}

	public virtual void OnControlled() {
		isInfected = true;
		directinIndicator.gameObject.SetActive(true);
		isControlled = true;
		canDoAction = true;

		if(alienTargetManager.HasConnectedAllAliens()) {
			directinIndicator.gameObject.SetActive(false);
		}
	}

	public bool CanDoAction() {
		return canDoAction;
	}

	public void Kill() {
		//play sound
		if(bloodAnimations != null) {
			int bloodAnimationIndex = Random.Range(0, bloodAnimations.Length);
			bloodAnimations[bloodAnimationIndex].transform.parent = null;
			bloodAnimations[bloodAnimationIndex].Play(true);
			explosionSound.PlayIndependent(true);
		}
		this.gameObject.SetActive(false);
	}

	public virtual Transform GetCenterTransform() {
		return this.transform;
	}
}

