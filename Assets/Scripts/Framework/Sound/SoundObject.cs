using UnityEngine;
using System.Collections;

public class SoundObject : DispatchBehaviour {

	public SoundType soundType = SoundType.FX;
	public float soundVolumePercentage = 1f;

	protected float originalVolume, volumeBeforeMute, originalPitch, originalVolumePercentage;
	private float originalTimeScale;

	protected bool isMuted = false;
	protected bool destroyOnDone = false;
	private bool isPaused = false;

	public bool useOverrideVolumePercentage = false;
	protected float overrideVolumePercentage = -1f;

	public void Start() {
	}
	
	public void FixedUpdate() {
		if(destroyOnDone && !GetSound().isPlaying) {
			Destroy (this.gameObject);
		}
	}
	
	// Use this for initialization
	public virtual void Awake () {
		originalVolume = GetSound().volume;
		originalPitch = GetSound ().pitch;
		originalVolumePercentage = soundVolumePercentage;
		volumeBeforeMute = originalVolume;

		originalTimeScale = GetSound().pitch;
	}

	public AudioSource GetSound() {
		return this.GetComponent<AudioSource>();
	}
	
	public virtual void SetVolume(float newVolume) {
		if(newVolume > 0) {
			this.GetSound ().volume = newVolume * (useOverrideVolumePercentage ? overrideVolumePercentage : soundVolumePercentage);
		} else {
			if(newVolume < 0) {
				this.GetSound().volume = 0;
			} else {
				this.GetSound().volume = newVolume;
			}
		}
	}

	public void SetOverrideVolumePercentage(float volumePercentage) {
		this.overrideVolumePercentage = volumePercentage;
	}

	public void SetUseOverrideVolumePercentage(bool useOverrideVolumePercentage) {
		this.useOverrideVolumePercentage = useOverrideVolumePercentage;
	}

	public float GetVolume() {
		return GetSound().volume;
	}

	public void SetTimeScale(float newTimeScale) {
		this.GetSound().pitch = newTimeScale;
	}

	public void ResetTimeScale() {
		this.GetSound().pitch = originalTimeScale;
	}

	public void Play(bool force = true) {
		if(gameObject.activeInHierarchy) {
			if(force) {
				GetSound().Play();
			} else if(!GetSound().isPlaying) {
				GetSound().Play();
			}

		}
	}

	public void Resume() {
		if(isPaused) {
			isPaused = false;
			GetSound().Play ();
		}
	}

	public void Pause() {
		isPaused = true;
		GetSound().Pause();
	}

	public void PlayScheduled(double timeToStart) {
		GetSound().PlayScheduled(timeToStart);
	}
	public void PlayIndependent(bool destroyOnDone = true) {
		this.transform.parent = null;
		Play ();
		this.destroyOnDone = destroyOnDone;
	}
	
	public void Stop() {
		GetSound().Stop();
	}

	public void Mute() {
		volumeBeforeMute = GetSound().volume;
		GetSound().volume = 0f;

		isMuted = true;
	}

	public void UnMute() {
		GetSound().volume = volumeBeforeMute;
		isMuted = false;
	}

	public bool IsPaused() {
		return isPaused;
	}

    public bool IsPlaying() {
        return GetSound().isPlaying;
    }

	public float GetOriginalPitch() {
		return originalPitch;
	}

	public float GetOriginalVolumePercentage() {
		return originalVolumePercentage;
	}
}
