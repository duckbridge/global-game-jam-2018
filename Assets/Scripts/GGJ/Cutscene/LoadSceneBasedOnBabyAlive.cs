using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Cutscenes {
	public class LoadSceneBasedOnBabyAlive : CutSceneComponent {

		public Scene sceneToLoadOnBabyDead;
		public Scene sceneToLoad;
		public override void OnActivated () {
			if(SceneUtils.FindObject<BabyAlienTarget>()) {
				SceneManager.LoadScene(sceneToLoad.ToString());
			} else {
				SceneManager.LoadScene(sceneToLoadOnBabyDead.ToString());				
			}
		}
	}
}
