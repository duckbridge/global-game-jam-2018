using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Animation2DThatPlaysSoundEffectAndShakesCamera : Animation2D {

	public float cameraShakeAmount = .2f;
	public SoundObject soundEffect;
	public List<int> framesToPlaySoundEffectOn;


	public override void OnFrameEntered (int enteredFrame) {
		if(framesToPlaySoundEffectOn.Contains(enteredFrame)) {
			soundEffect.Play(true);
			SceneUtils.FindObject<CameraShaker> ().ZoomShakeCamera (cameraShakeAmount);
		}
	}
}
