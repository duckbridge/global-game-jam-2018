using UnityEngine;
using System.Collections;

public class CameraShaker : MonoBehaviour {

	public bool canShakeCamera = true;
	public float cameraShakeTime = .05f;
	public float cameraShakeOffset = .05f;
	private Vector3 shakeScale = Vector3.one;

	private Vector3 savedLocalPosition;
	public Camera _camera;
	private float originalOrthographicSize;
	private float zoomInSizeOnShake = 19.7f;
	protected float zoomOutSizeOnShake = 20f;

	private float cameraZoomShakeTimeToUse;

	public void Awake() {
		if (!this._camera) {
			this._camera = GetComponent<Camera> ();
		}
		if (this._camera != null) {
			originalOrthographicSize = _camera.orthographicSize;
		}
	}

	public void Start() {
        int canShakeCameraSaved = PlayerPrefs.GetInt("TEMP_BBW_CAMERASHAKETOGGLE", 1);
        canShakeCamera = (canShakeCameraSaved == 1 ? true : false);
    }

	public void Update() {}

	public void ZoomShakeCamera(float zoomAmount, float cameraZoomShakeTime = 0f, bool reset = true) {

		if (cameraZoomShakeTime <= 0) {
			cameraZoomShakeTime = cameraShakeTime;
		}

		cameraZoomShakeTimeToUse = cameraZoomShakeTime;

		if(!canShakeCamera) {
			return;
		}

		CancelInvoke("ResetZoom");

		iTween.StopByName (this.gameObject, "InOutZoom");
		ResetZoom ();

		this.zoomInSizeOnShake = _camera.orthographicSize - zoomAmount;
		this.zoomOutSizeOnShake = _camera.orthographicSize;

		CancelInvoke ("ZoomIn");
		CancelInvoke ("ZoomOut");

		ZoomIn();
		Invoke ("ZoomOut", cameraZoomShakeTimeToUse);

		Invoke ("ResetZoom", cameraZoomShakeTimeToUse * 2);

	}

	public void ShakeShakeCamera(Vector2 shakeScale, bool reset = true) {

		if(!canShakeCamera) {
			return;
		}
			
		this.shakeScale = shakeScale;

		if(reset) {
			ResetShake();
		}

		CancelInvoke ("ShakeRight");
		CancelInvoke ("ShakeLeft");
		CancelInvoke ("ShakeUp");
		CancelInvoke ("ShakeDown");

		ShakeLeft ();
		Invoke ("ShakeRight", cameraShakeTime);

		Invoke ("ShakeLeft", cameraShakeTime * 2);
		Invoke ("ShakeRight", cameraShakeTime * 3);

		Invoke ("ShakeUp", cameraShakeTime * 3);
		Invoke ("ShakeDown", cameraShakeTime * 2);

		Invoke ("ResetShake", cameraShakeTime * 4);
	}

	public void OnZoomed(float newValue) {
		_camera.orthographicSize = newValue;
	}

	private void ZoomIn() {
		iTween.ValueTo(this.gameObject, new ITweenBuilder()
			.SetFromAndTo((float)_camera.orthographicSize, zoomInSizeOnShake)
			.SetEaseType(iTween.EaseType.easeOutBack)
			.SetTime(cameraZoomShakeTimeToUse)
			.SetName("InOutZoom")
			.SetOnUpdate("OnZoomed")
			.Build());
		// _camera.orthographicSize = zoomInSizeOnShake;
	}

	private void ZoomOut() {
		iTween.ValueTo(this.gameObject, new ITweenBuilder()
			.SetFromAndTo((float)_camera.orthographicSize, zoomOutSizeOnShake)
			.SetEaseType(iTween.EaseType.easeInBack)
			.SetTime(cameraZoomShakeTimeToUse)
			.SetName("InOutZoom")
			.SetOnUpdate("OnZoomed")
			.Build());
		// _camera.orthographicSize = zoomOutSizeOnShake;
	}

	private void ShakeLeft() {
		this.transform.localPosition = new Vector3(this.transform.localPosition.x - (cameraShakeOffset * shakeScale.x), this.transform.localPosition.y, this.transform.localPosition.z);
	}
	
	private void ShakeRight() {
		this.transform.localPosition = new Vector3(this.transform.localPosition.x + (cameraShakeOffset * shakeScale.x), this.transform.localPosition.y, this.transform.localPosition.z);
	}

	private void ShakeUp() {
		this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.y  - (cameraShakeOffset * shakeScale.y));
	}

	private void ShakeDown() {
		this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.y  + (cameraShakeOffset * shakeScale.y));
	}

	private void ResetShake() {
		this.transform.localPosition = Vector3.zero;
	}

	protected virtual void ResetZoom() {
		_camera.orthographicSize = originalOrthographicSize;
	}

	private bool CanZoomOnShake() {
		return this._camera != null;
	}
}
