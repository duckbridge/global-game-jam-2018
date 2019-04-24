using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TextCutSceneComponent : CutSceneComponent {
    public bool waitsUntillHidingAnimationDone = true;

	public TextBoxManager textBoxManager;

	public override void OnActivated() {
        if(SceneUtils.FindObject<CrossInputListener>()) {
            SceneUtils.FindObject<CrossInputListener>().Show();
        }

		textBoxManager.AddEventListener(this.gameObject);
		textBoxManager.ResetShowAndActivate(0);
	}

	private void OnTextBoxDoneAndHidden() {
        if(SceneUtils.FindObject<CrossInputListener>()) {
            SceneUtils.FindObject<CrossInputListener>().Hide();
        }
        if(waitsUntillHidingAnimationDone) {
		    DeActivate();
        }
	}

    public void OnTextDone() {
        if(SceneUtils.FindObject<CrossInputListener>()) {
            SceneUtils.FindObject<CrossInputListener>().Hide();
        }
        if(!waitsUntillHidingAnimationDone) {
            DeActivate();
        }
    }
}
