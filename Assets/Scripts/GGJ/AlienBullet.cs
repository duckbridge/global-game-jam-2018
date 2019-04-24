using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienBullet : MonoBehaviour {
	public RopeContainer ropeContainerPrefab;
	public float bulletSpeed = 10f;

	private GameObject originGo, source;

	private Camera gameCamera;

	private bool canResetTheGame = true;

	private RopeContainer ropeContainer;
	
	// Use this for initialization
	void Start () {
		gameCamera = GameObject.Find("GameCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		if(gameCamera) {
			Bounds cameraBounds = MathUtils.OrthographicBounds(gameCamera);
			
			float minimumX = gameCamera.transform.position.x - cameraBounds.extents.x;
			float maximumX = gameCamera.transform.position.x + cameraBounds.extents.x;
			float minimumY = gameCamera.transform.position.z - cameraBounds.extents.z;
			float maximumY = gameCamera.transform.position.z + cameraBounds.extents.z;

			if(this.transform.position.x < minimumX || this.transform.position.x > maximumX ||
			 this.transform.position.z < minimumY || this.transform.position.z > maximumY) {
				if(canResetTheGame) {
					canResetTheGame = false;
					Invoke("ResetGame", 1f);
				}
			}
		}
	}

	private void ResetGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Shoot(Vector3 shootDirection) {
		this.GetComponent<Rigidbody>().AddForce(shootDirection * bulletSpeed, ForceMode.Impulse);	
		if(ropeContainerPrefab != null) {
			ropeContainer = GameObject.Instantiate(ropeContainerPrefab, this.transform.position, Quaternion.identity);
			ropeContainer.AddEventListener(this.gameObject);

			Transform originTransform = GetOriginGo().transform;
			if(GetOriginGo().GetComponent<AlienTarget>()) {
				originTransform = 
				GetOriginGo().GetComponent<AlienTarget>()
				.GetCenterTransform();
			}
			ropeContainer.ExtendRope(originTransform, this.transform);
		}
	}

	public void BeforeDestroy() {
		if(ropeContainer != null) {
			Destroy(ropeContainer.gameObject);
		}
	}

	public void SetSource(GameObject source) {
		this.source = source;
	}
	public void SetOriginGo(GameObject originGo) {
		this.originGo = originGo;
	}

	public GameObject GetOriginGo() {
		return this.originGo;
	}

	public GameObject GetSource() {
		return source;
	}
}
