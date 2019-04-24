using UnityEngine;
using System.Collections;

namespace Cutscenes {
	public class PlayAnimation2D : CutSceneComponent {

		public float cutsceneTimeout = .5f;
		public AnimationManager2D animationManager;
		
		public string animationName;

		public override void OnActivated () {

			if(!animationManager.IsInitialized()) {
				animationManager.Initialize();
			}

			animationManager.PlayAnimationByName(animationName, true, false, true);
			
			Invoke ("DeActivate", cutsceneTimeout);
		}
	}
}
