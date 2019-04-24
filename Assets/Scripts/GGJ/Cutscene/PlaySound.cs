using UnityEngine;
using System.Collections;

namespace Cutscenes {
	public class PlaySound : CutSceneComponent {

		public float cutsceneTimeout = .5f;
		public SoundObject soundObject;

		public override void OnActivated () {
			soundObject.Play(true);
			Invoke ("DeActivate", cutsceneTimeout);
		}
	}
}
