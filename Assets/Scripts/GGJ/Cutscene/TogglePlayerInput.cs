using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Cutscenes {
	public class TogglePlayerInput : CutSceneComponent {

		public bool enablePlayerInput = true;

		public override void OnActivated () {
			SceneUtils.FindObject<AlienTargetManager>().TogglePlayerInput(enablePlayerInput);
			DeActivate();
		}
	}
}