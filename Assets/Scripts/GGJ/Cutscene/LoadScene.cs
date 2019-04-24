using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Cutscenes {
	public class LoadScene : CutSceneComponent {

		public Scene sceneToLoad;
		public override void OnActivated () {
			SceneManager.LoadScene(sceneToLoad.ToString());
		}
	}
}
