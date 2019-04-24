using UnityEngine;
using System.Collections;

public class IntroCameraShaker : CameraShaker {

	protected override void ResetZoom () {
		_camera.orthographicSize = zoomOutSizeOnShake;
	}
}
