using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Cutscenes {
	public class StartGame : CutSceneComponent {

		public override void OnActivated () {
			SceneUtils.FindObject<AlienTargetManager>().currentAlienTarget.OnControlled();
			DeActivate();
		}
	}
}