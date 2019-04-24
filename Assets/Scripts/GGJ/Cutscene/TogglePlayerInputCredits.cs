using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Cutscenes {
	public class TogglePlayerInputCredits : CutSceneComponent {

		public AlienTarget player;

		public override void OnActivated () {
			player.isControlled = true;
			DeActivate();
		}
	}
}