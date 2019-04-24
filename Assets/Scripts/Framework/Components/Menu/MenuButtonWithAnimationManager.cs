using UnityEngine;
using System.Collections;

public class MenuButtonWithAnimationManager : MenuButtonWithId {

	public string animationName;
	public AnimationManager2D animationManager;

	public override void OnSelected () {
		base.OnSelected ();
		animationManager.PlayAnimationByName (animationName, true);
	}
}
