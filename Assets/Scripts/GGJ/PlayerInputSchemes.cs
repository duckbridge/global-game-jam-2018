using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerInputSchemes : MonoBehaviour {

	public static bool isInverted = false;
	public enum InputSchemes { A, B, C }
	public enum InputSchemeTypes { ONLYKEYBOARD, ONLYCONTROLLER, BOTH }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static PlayerInputActions GetScheme(InputSchemes scheme, InputSchemeTypes schemeType) {
		Logger.Log ("getting scheme " + scheme);
		PlayerInputActions playerInputActions = new PlayerInputActions ();

		switch (scheme) {
			case InputSchemes.A:
				switch (schemeType) {
					case InputSchemeTypes.BOTH:
						Scheme_A_KeyboardInputs (ref playerInputActions);
						Scheme_A_ControllerInputs (ref playerInputActions);
					break;
					case InputSchemeTypes.ONLYCONTROLLER:
						Scheme_A_ControllerInputs (ref playerInputActions);
					break;
					case InputSchemeTypes.ONLYKEYBOARD:
						Scheme_A_KeyboardInputs (ref playerInputActions);
					break;
				}
			break;

			case InputSchemes.B:
				switch (schemeType) {
					case InputSchemeTypes.BOTH:
						Scheme_B_KeyboardInputs (ref playerInputActions);
						Scheme_B_ControllerInputs (ref playerInputActions);
					break;
					case InputSchemeTypes.ONLYCONTROLLER:
						Scheme_B_ControllerInputs (ref playerInputActions);
					break;
					case InputSchemeTypes.ONLYKEYBOARD:
						Scheme_B_KeyboardInputs (ref playerInputActions);
					break;
				}
			break;

			case InputSchemes.C:
				switch (schemeType) {
				case InputSchemeTypes.BOTH:
					Scheme_C_KeyboardInputs (ref playerInputActions);
					Scheme_C_ControllerInputs (ref playerInputActions);
				break;
				case InputSchemeTypes.ONLYCONTROLLER:
					Scheme_C_ControllerInputs (ref playerInputActions);
				break;
				case InputSchemeTypes.ONLYKEYBOARD:
					Scheme_C_KeyboardInputs (ref playerInputActions);
				break;
			}
			break;
		}

		return playerInputActions;
	}

	private static void Scheme_A_ControllerInputs(ref PlayerInputActions playerInputActions) {

		if(isInverted) {
			playerInputActions.left.AddDefaultBinding(InputControlType.LeftStickRight);
			playerInputActions.left.AddDefaultBinding(InputControlType.DPadRight);

			playerInputActions.right.AddDefaultBinding(InputControlType.LeftStickRight);
			playerInputActions.right.AddDefaultBinding(InputControlType.DPadRight);

			playerInputActions.up.AddDefaultBinding(InputControlType.LeftStickDown);
			playerInputActions.up.AddDefaultBinding(InputControlType.DPadDown);

			playerInputActions.down.AddDefaultBinding(InputControlType.LeftStickUp);
			playerInputActions.down.AddDefaultBinding(InputControlType.DPadUp);

			playerInputActions.rStickLeft.AddDefaultBinding(InputControlType.RightStickLeft);
			playerInputActions.rStickRight.AddDefaultBinding(InputControlType.RightStickRight);
			playerInputActions.rStickUp.AddDefaultBinding(InputControlType.RightStickUp);
			playerInputActions.rStickDown.AddDefaultBinding(InputControlType.RightStickDown);

			playerInputActions.menuSelect.AddDefaultBinding(InputControlType.Action2);
			playerInputActions.interact.AddDefaultBinding(InputControlType.Action2);

			playerInputActions.pause.AddDefaultBinding(InputControlType.Command);
			playerInputActions.back.AddDefaultBinding(InputControlType.Action1);
			playerInputActions.secondAttack.AddDefaultBinding(InputControlType.RightBumper);
			playerInputActions.thirdAttack.AddDefaultBinding(InputControlType.LeftBumper);

			playerInputActions.roll.AddDefaultBinding(InputControlType.Action3);
			playerInputActions.previousTrack.AddDefaultBinding(InputControlType.RightTrigger);
			playerInputActions.nextTrack.AddDefaultBinding(InputControlType.LeftTrigger);

			playerInputActions.dance.AddDefaultBinding (InputControlType.Action1);
		} else {
			playerInputActions.left.AddDefaultBinding(InputControlType.LeftStickLeft);
			playerInputActions.left.AddDefaultBinding(InputControlType.DPadLeft);

			playerInputActions.right.AddDefaultBinding(InputControlType.LeftStickRight);
			playerInputActions.right.AddDefaultBinding(InputControlType.DPadRight);

			playerInputActions.up.AddDefaultBinding(InputControlType.LeftStickUp);
			playerInputActions.up.AddDefaultBinding(InputControlType.DPadUp);

			playerInputActions.down.AddDefaultBinding(InputControlType.LeftStickDown);
			playerInputActions.down.AddDefaultBinding(InputControlType.DPadDown);

			playerInputActions.rStickLeft.AddDefaultBinding(InputControlType.RightStickLeft);
			playerInputActions.rStickRight.AddDefaultBinding(InputControlType.RightStickRight);
			playerInputActions.rStickUp.AddDefaultBinding(InputControlType.RightStickUp);
			playerInputActions.rStickDown.AddDefaultBinding(InputControlType.RightStickDown);

			playerInputActions.menuSelect.AddDefaultBinding(InputControlType.Action1);
			playerInputActions.interact.AddDefaultBinding(InputControlType.Action1);

			playerInputActions.pause.AddDefaultBinding(InputControlType.Command);
			playerInputActions.back.AddDefaultBinding(InputControlType.Action2);
			playerInputActions.secondAttack.AddDefaultBinding(InputControlType.LeftBumper);
			playerInputActions.thirdAttack.AddDefaultBinding(InputControlType.RightBumper);

			playerInputActions.roll.AddDefaultBinding(InputControlType.Action3);
			playerInputActions.previousTrack.AddDefaultBinding(InputControlType.LeftTrigger);
			playerInputActions.nextTrack.AddDefaultBinding(InputControlType.RightTrigger);

			playerInputActions.dance.AddDefaultBinding (InputControlType.Action2);
		}
	}

	private static void Scheme_A_KeyboardInputs(ref PlayerInputActions playerInputActions) {

		//playerInputActions.Device =  //TODO: find keyboard device!

		if(isInverted) {
			playerInputActions.menuLeft.AddDefaultBinding(Key.RightArrow);
			playerInputActions.menuRight.AddDefaultBinding(Key.LeftArrow);
			playerInputActions.menuUp.AddDefaultBinding(Key.DownArrow);
			playerInputActions.menuDown.AddDefaultBinding(Key.UpArrow);
			playerInputActions.menuSelect.AddDefaultBinding (Key.Return);

			playerInputActions.left.AddDefaultBinding(Key.RightArrow);
			playerInputActions.right.AddDefaultBinding(Key.LeftArrow);
			playerInputActions.up.AddDefaultBinding(Key.DownArrow);
			playerInputActions.down.AddDefaultBinding(Key.UpArrow);

			playerInputActions.rStickLeft.AddDefaultBinding(Key.D);
			playerInputActions.rStickRight.AddDefaultBinding(Key.A);
			playerInputActions.rStickUp.AddDefaultBinding(Key.S);
			playerInputActions.rStickDown.AddDefaultBinding(Key.W);

			playerInputActions.menuSelect.AddDefaultBinding(Key.S);
			playerInputActions.interact.AddDefaultBinding(Key.S);

			playerInputActions.pause.AddDefaultBinding(Key.Escape);
			playerInputActions.pause.AddDefaultBinding(Key.Tab);
			playerInputActions.back.AddDefaultBinding(Key.S);
			playerInputActions.secondAttack.AddDefaultBinding(Key.S);
			playerInputActions.thirdAttack.AddDefaultBinding(Key.R);

			playerInputActions.roll.AddDefaultBinding(Key.LeftShift);
			playerInputActions.previousTrack.AddDefaultBinding(Key.Q);
			playerInputActions.nextTrack.AddDefaultBinding(Key.E);

			playerInputActions.dance.AddDefaultBinding (Key.Q);
		} else {
			playerInputActions.menuLeft.AddDefaultBinding(Key.LeftArrow);
			playerInputActions.menuRight.AddDefaultBinding(Key.RightArrow);
			playerInputActions.menuUp.AddDefaultBinding(Key.UpArrow);
			playerInputActions.menuDown.AddDefaultBinding(Key.DownArrow);
			playerInputActions.menuSelect.AddDefaultBinding (Key.Return);

			playerInputActions.left.AddDefaultBinding(Key.LeftArrow);
			playerInputActions.right.AddDefaultBinding(Key.RightArrow);
			playerInputActions.up.AddDefaultBinding(Key.UpArrow);
			playerInputActions.down.AddDefaultBinding(Key.DownArrow);

			playerInputActions.rStickLeft.AddDefaultBinding(Key.A);
			playerInputActions.rStickRight.AddDefaultBinding(Key.D);
			playerInputActions.rStickUp.AddDefaultBinding(Key.W);
			playerInputActions.rStickDown.AddDefaultBinding(Key.S);

			playerInputActions.menuSelect.AddDefaultBinding(Key.D);
			playerInputActions.interact.AddDefaultBinding(Key.D);

			playerInputActions.pause.AddDefaultBinding(Key.Escape);
			playerInputActions.pause.AddDefaultBinding(Key.Tab);
			playerInputActions.back.AddDefaultBinding(Key.S);
			playerInputActions.secondAttack.AddDefaultBinding(Key.S);
			playerInputActions.thirdAttack.AddDefaultBinding(Key.Q);

			playerInputActions.roll.AddDefaultBinding(Key.LeftShift);
			playerInputActions.previousTrack.AddDefaultBinding(Key.Q);
			playerInputActions.nextTrack.AddDefaultBinding(Key.E);

			playerInputActions.dance.AddDefaultBinding (Key.R);
		}
	}

	private static void Scheme_B_ControllerInputs(ref PlayerInputActions playerInputActions) {

		if(isInverted) {
			playerInputActions.left.AddDefaultBinding(InputControlType.LeftStickRight);
			playerInputActions.left.AddDefaultBinding(InputControlType.DPadRight);

			playerInputActions.right.AddDefaultBinding(InputControlType.LeftStickLeft);
			playerInputActions.right.AddDefaultBinding(InputControlType.DPadLeft);

			playerInputActions.up.AddDefaultBinding(InputControlType.LeftStickDown);
			playerInputActions.up.AddDefaultBinding(InputControlType.DPadDown);

			playerInputActions.down.AddDefaultBinding(InputControlType.LeftStickUp);
			playerInputActions.down.AddDefaultBinding(InputControlType.DPadUp);

			playerInputActions.rStickLeft.AddDefaultBinding(InputControlType.RightStickLeft);
			playerInputActions.rStickRight.AddDefaultBinding(InputControlType.RightStickRight);
			playerInputActions.rStickUp.AddDefaultBinding(InputControlType.RightStickUp);
			playerInputActions.rStickDown.AddDefaultBinding(InputControlType.RightStickDown);

			playerInputActions.menuSelect.AddDefaultBinding(InputControlType.Action2);
			playerInputActions.interact.AddDefaultBinding(InputControlType.Action2);

			playerInputActions.pause.AddDefaultBinding(InputControlType.Command);
			playerInputActions.back.AddDefaultBinding(InputControlType.Action1);
			playerInputActions.secondAttack.AddDefaultBinding(InputControlType.RightBumper);
			playerInputActions.thirdAttack.AddDefaultBinding(InputControlType.LeftBumper);

			playerInputActions.roll.AddDefaultBinding(InputControlType.Action3);
			playerInputActions.previousTrack.AddDefaultBinding(InputControlType.LeftTrigger);
			playerInputActions.nextTrack.AddDefaultBinding(InputControlType.RightTrigger);

			playerInputActions.dance.AddDefaultBinding (InputControlType.Action1);
		} else {
			playerInputActions.left.AddDefaultBinding(InputControlType.LeftStickLeft);
			playerInputActions.left.AddDefaultBinding(InputControlType.DPadLeft);

			playerInputActions.right.AddDefaultBinding(InputControlType.LeftStickRight);
			playerInputActions.right.AddDefaultBinding(InputControlType.DPadRight);

			playerInputActions.up.AddDefaultBinding(InputControlType.LeftStickUp);
			playerInputActions.up.AddDefaultBinding(InputControlType.DPadUp);

			playerInputActions.down.AddDefaultBinding(InputControlType.LeftStickDown);
			playerInputActions.down.AddDefaultBinding(InputControlType.DPadDown);

			playerInputActions.rStickLeft.AddDefaultBinding(InputControlType.RightStickLeft);
			playerInputActions.rStickRight.AddDefaultBinding(InputControlType.RightStickRight);
			playerInputActions.rStickUp.AddDefaultBinding(InputControlType.RightStickUp);
			playerInputActions.rStickDown.AddDefaultBinding(InputControlType.RightStickDown);

			playerInputActions.menuSelect.AddDefaultBinding(InputControlType.Action1);
			playerInputActions.interact.AddDefaultBinding(InputControlType.Action1);

			playerInputActions.pause.AddDefaultBinding(InputControlType.Command);
			playerInputActions.back.AddDefaultBinding(InputControlType.Action2);
			playerInputActions.secondAttack.AddDefaultBinding(InputControlType.LeftBumper);
			playerInputActions.thirdAttack.AddDefaultBinding(InputControlType.RightBumper);

			playerInputActions.roll.AddDefaultBinding(InputControlType.Action3);
			playerInputActions.previousTrack.AddDefaultBinding(InputControlType.LeftTrigger);
			playerInputActions.nextTrack.AddDefaultBinding(InputControlType.RightTrigger);

			playerInputActions.dance.AddDefaultBinding (InputControlType.Action2);
		}
	}

	private static void Scheme_B_KeyboardInputs(ref PlayerInputActions playerInputActions) {

		//playerInputActions.Device =  //TODO: find keyboard device!
		if(isInverted) {
			playerInputActions.menuLeft.AddDefaultBinding(Key.RightArrow);
			playerInputActions.menuRight.AddDefaultBinding(Key.LeftArrow);
			playerInputActions.menuUp.AddDefaultBinding(Key.DownArrow);
			playerInputActions.menuDown.AddDefaultBinding(Key.UpArrow);
			playerInputActions.menuSelect.AddDefaultBinding (Key.Return);

			playerInputActions.left.AddDefaultBinding(Key.D);
			playerInputActions.right.AddDefaultBinding(Key.A);
			playerInputActions.up.AddDefaultBinding(Key.S);
			playerInputActions.down.AddDefaultBinding(Key.W);

			playerInputActions.menuSelect.AddDefaultBinding(Key.K);
			playerInputActions.interact.AddDefaultBinding(Key.K);

			playerInputActions.pause.AddDefaultBinding(Key.Escape);
			playerInputActions.pause.AddDefaultBinding(Key.Tab);
			playerInputActions.back.AddDefaultBinding(Key.J);
			playerInputActions.secondAttack.AddDefaultBinding(Key.J);
			playerInputActions.thirdAttack.AddDefaultBinding(Key.O);

			playerInputActions.roll.AddDefaultBinding(Key.LeftShift);
			playerInputActions.previousTrack.AddDefaultBinding(Key.Q);
			playerInputActions.nextTrack.AddDefaultBinding(Key.E);

			playerInputActions.dance.AddDefaultBinding (Key.J);
		} else {
			playerInputActions.menuLeft.AddDefaultBinding(Key.LeftArrow);
			playerInputActions.menuRight.AddDefaultBinding(Key.RightArrow);
			playerInputActions.menuUp.AddDefaultBinding(Key.UpArrow);
			playerInputActions.menuDown.AddDefaultBinding(Key.DownArrow);
			playerInputActions.menuSelect.AddDefaultBinding (Key.Return);

			playerInputActions.left.AddDefaultBinding(Key.A);
			playerInputActions.right.AddDefaultBinding(Key.D);
			playerInputActions.up.AddDefaultBinding(Key.W);
			playerInputActions.down.AddDefaultBinding(Key.S);

			playerInputActions.menuSelect.AddDefaultBinding(Key.J);
			playerInputActions.interact.AddDefaultBinding(Key.J);

			playerInputActions.pause.AddDefaultBinding(Key.Escape);
			playerInputActions.pause.AddDefaultBinding(Key.Tab);
			playerInputActions.back.AddDefaultBinding(Key.K);
			playerInputActions.secondAttack.AddDefaultBinding(Key.K);
			playerInputActions.thirdAttack.AddDefaultBinding(Key.I);

			playerInputActions.roll.AddDefaultBinding(Key.LeftShift);
			playerInputActions.previousTrack.AddDefaultBinding(Key.Q);
			playerInputActions.nextTrack.AddDefaultBinding(Key.E);

			playerInputActions.dance.AddDefaultBinding (Key.O );
		}
	}

	private static void Scheme_C_ControllerInputs(ref PlayerInputActions playerInputActions) {

		if(isInverted) {
			playerInputActions.left.AddDefaultBinding(InputControlType.LeftStickRight);
			playerInputActions.left.AddDefaultBinding(InputControlType.DPadRight);

			playerInputActions.right.AddDefaultBinding(InputControlType.LeftStickRight);
			playerInputActions.right.AddDefaultBinding(InputControlType.DPadRight);

			playerInputActions.up.AddDefaultBinding(InputControlType.LeftStickDown);
			playerInputActions.up.AddDefaultBinding(InputControlType.DPadDown);

			playerInputActions.down.AddDefaultBinding(InputControlType.LeftStickUp);
			playerInputActions.down.AddDefaultBinding(InputControlType.DPadUp);

			playerInputActions.rStickLeft.AddDefaultBinding(InputControlType.RightStickLeft);
			playerInputActions.rStickRight.AddDefaultBinding(InputControlType.RightStickRight);
			playerInputActions.rStickUp.AddDefaultBinding(InputControlType.RightStickUp);
			playerInputActions.rStickDown.AddDefaultBinding(InputControlType.RightStickDown);

			playerInputActions.menuSelect.AddDefaultBinding(InputControlType.Action2);
			playerInputActions.interact.AddDefaultBinding(InputControlType.Action2);

			playerInputActions.pause.AddDefaultBinding(InputControlType.Command);
			playerInputActions.back.AddDefaultBinding(InputControlType.Action1);
			playerInputActions.secondAttack.AddDefaultBinding(InputControlType.RightBumper);
			playerInputActions.thirdAttack.AddDefaultBinding(InputControlType.LeftBumper);

			playerInputActions.roll.AddDefaultBinding(InputControlType.Action3);
			playerInputActions.previousTrack.AddDefaultBinding(InputControlType.RightTrigger);
			playerInputActions.nextTrack.AddDefaultBinding(InputControlType.LeftTrigger);

			playerInputActions.dance.AddDefaultBinding (InputControlType.Action1);
		} else {
			playerInputActions.left.AddDefaultBinding(InputControlType.LeftStickLeft);
			playerInputActions.left.AddDefaultBinding(InputControlType.DPadLeft);

			playerInputActions.right.AddDefaultBinding(InputControlType.LeftStickRight);
			playerInputActions.right.AddDefaultBinding(InputControlType.DPadRight);

			playerInputActions.up.AddDefaultBinding(InputControlType.LeftStickUp);
			playerInputActions.up.AddDefaultBinding(InputControlType.DPadUp);

			playerInputActions.down.AddDefaultBinding(InputControlType.LeftStickDown);
			playerInputActions.down.AddDefaultBinding(InputControlType.DPadDown);

			playerInputActions.rStickLeft.AddDefaultBinding(InputControlType.RightStickLeft);
			playerInputActions.rStickRight.AddDefaultBinding(InputControlType.RightStickRight);
			playerInputActions.rStickUp.AddDefaultBinding(InputControlType.RightStickUp);
			playerInputActions.rStickDown.AddDefaultBinding(InputControlType.RightStickDown);

			playerInputActions.menuSelect.AddDefaultBinding(InputControlType.Action1);
			playerInputActions.interact.AddDefaultBinding(InputControlType.Action1);

			playerInputActions.pause.AddDefaultBinding(InputControlType.Command);
			playerInputActions.back.AddDefaultBinding(InputControlType.Action2);
			playerInputActions.secondAttack.AddDefaultBinding(InputControlType.LeftBumper);
			playerInputActions.thirdAttack.AddDefaultBinding(InputControlType.RightBumper);

			playerInputActions.roll.AddDefaultBinding(InputControlType.Action3);
			playerInputActions.previousTrack.AddDefaultBinding(InputControlType.LeftTrigger);
			playerInputActions.nextTrack.AddDefaultBinding(InputControlType.RightTrigger);

			playerInputActions.dance.AddDefaultBinding (InputControlType.Action2);
		}
	}

	private static void Scheme_C_KeyboardInputs(ref PlayerInputActions playerInputActions) {

		//playerInputActions.Device =  //TODO: find keyboard device!

	if(isInverted) {
			playerInputActions.menuLeft.AddDefaultBinding(Key.RightArrow);
			playerInputActions.menuRight.AddDefaultBinding(Key.LeftArrow);
			playerInputActions.menuUp.AddDefaultBinding(Key.DownArrow);
			playerInputActions.menuDown.AddDefaultBinding(Key.UpArrow);
			playerInputActions.menuSelect.AddDefaultBinding (Key.Return);

			playerInputActions.left.AddDefaultBinding(Key.RightArrow);
			playerInputActions.right.AddDefaultBinding(Key.LeftArrow);
			playerInputActions.up.AddDefaultBinding(Key.DownArrow);
			playerInputActions.down.AddDefaultBinding(Key.UpArrow);

			playerInputActions.rStickLeft.AddDefaultBinding(Key.D);
			playerInputActions.rStickRight.AddDefaultBinding(Key.A);
			playerInputActions.rStickUp.AddDefaultBinding(Key.S);
			playerInputActions.rStickDown.AddDefaultBinding(Key.W);

			playerInputActions.menuSelect.AddDefaultBinding(Key.S);
			playerInputActions.interact.AddDefaultBinding(Key.S);

			playerInputActions.pause.AddDefaultBinding(Key.Escape);
			playerInputActions.pause.AddDefaultBinding(Key.Tab);
			playerInputActions.back.AddDefaultBinding(Key.S);
			playerInputActions.secondAttack.AddDefaultBinding(Key.S);
			playerInputActions.thirdAttack.AddDefaultBinding(Key.R);

			playerInputActions.roll.AddDefaultBinding(Key.LeftShift);
			playerInputActions.previousTrack.AddDefaultBinding(Key.Q);
			playerInputActions.nextTrack.AddDefaultBinding(Key.E);

			playerInputActions.dance.AddDefaultBinding (Key.Q);
		} else {
			playerInputActions.menuLeft.AddDefaultBinding(Key.LeftArrow);
			playerInputActions.menuRight.AddDefaultBinding(Key.RightArrow);
			playerInputActions.menuUp.AddDefaultBinding(Key.UpArrow);
			playerInputActions.menuDown.AddDefaultBinding(Key.DownArrow);
			playerInputActions.menuSelect.AddDefaultBinding (Key.Return);

			playerInputActions.left.AddDefaultBinding(Key.LeftArrow);
			playerInputActions.right.AddDefaultBinding(Key.RightArrow);
			playerInputActions.up.AddDefaultBinding(Key.UpArrow);
			playerInputActions.down.AddDefaultBinding(Key.DownArrow);

			playerInputActions.rStickLeft.AddDefaultBinding(Key.A);
			playerInputActions.rStickRight.AddDefaultBinding(Key.D);
			playerInputActions.rStickUp.AddDefaultBinding(Key.W);
			playerInputActions.rStickDown.AddDefaultBinding(Key.S);

			playerInputActions.menuSelect.AddDefaultBinding(Key.D);
			playerInputActions.interact.AddDefaultBinding(Key.D);

			playerInputActions.pause.AddDefaultBinding(Key.Escape);
			playerInputActions.pause.AddDefaultBinding(Key.Tab);
			playerInputActions.back.AddDefaultBinding(Key.S);
			playerInputActions.secondAttack.AddDefaultBinding(Key.S);
			playerInputActions.thirdAttack.AddDefaultBinding(Key.Q);

			playerInputActions.roll.AddDefaultBinding(Key.LeftShift);
			playerInputActions.previousTrack.AddDefaultBinding(Key.Q);
			playerInputActions.nextTrack.AddDefaultBinding(Key.E);

			playerInputActions.dance.AddDefaultBinding (Key.R);
		}
	}
}
