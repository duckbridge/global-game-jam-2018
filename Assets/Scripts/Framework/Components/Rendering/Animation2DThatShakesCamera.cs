using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Animation2DThatShakesCamera : Animation2D {

	public float cameraShakeAmount = .2f;
	public List<int> framesToShakeCameraOn;


	public override void OnFrameEntered (int enteredFrame) {
		if(framesToShakeCameraOn.Contains(enteredFrame)) {
			SceneUtils.FindObject<CameraShaker> ().ZoomShakeCamera (cameraShakeAmount);
		}
	}
}
