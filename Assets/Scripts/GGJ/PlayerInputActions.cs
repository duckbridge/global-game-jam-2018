using UnityEngine;
using System.Collections;

namespace InControl {

	public class PlayerInputActions : PlayerActionSet {

		public PlayerAction left;
		public PlayerAction right;

		public PlayerAction up;
		public PlayerAction down;

		public PlayerAction rStickLeft;
		public PlayerAction rStickRight;
		
		public PlayerAction rStickUp;
		public PlayerAction rStickDown;

		public PlayerAction pause;
		public PlayerAction back;

		public PlayerOneAxisAction moveHorizontally;
		public PlayerOneAxisAction moveVertically;

		public PlayerOneAxisAction throwHorizontally;
		public PlayerOneAxisAction throwVertically;

		public PlayerAction interact;
		public PlayerAction secondAttack, thirdAttack;
		public PlayerAction roll;

		public PlayerAction menuSelect, nextTrack, previousTrack, menuLeft, menuRight, menuUp, menuDown;
		public PlayerAction dance;

		public PlayerInputActions() {

			left = CreatePlayerAction( "left" );
			right = CreatePlayerAction( "right" );

			up = CreatePlayerAction( "up" );
			down = CreatePlayerAction( "down" );

			rStickLeft = CreatePlayerAction( "rStickLeft" );
			rStickRight = CreatePlayerAction( "rStickRight" );
			
			rStickUp = CreatePlayerAction( "rStickUp" );
			rStickDown = CreatePlayerAction( "rStickDown" );

			moveHorizontally = CreateOneAxisPlayerAction( left, right );
			moveVertically = CreateOneAxisPlayerAction( down, up );

			throwHorizontally = CreateOneAxisPlayerAction( rStickLeft, rStickRight );
			throwVertically = CreateOneAxisPlayerAction( rStickDown, rStickUp );

			interact = CreatePlayerAction("interact");
			secondAttack = CreatePlayerAction("secondAttack");
			thirdAttack = CreatePlayerAction("thirdAttack");

			nextTrack = CreatePlayerAction("nextTrack");
			previousTrack = CreatePlayerAction("previousTrack");

			roll = CreatePlayerAction("roll");

			pause = CreatePlayerAction("pause");
			back = CreatePlayerAction ("back");

			menuSelect = CreatePlayerAction("menuSelect");
			menuLeft = CreatePlayerAction( "menuLeft" );
			menuRight = CreatePlayerAction( "menuRight" );

			menuUp = CreatePlayerAction( "menuUp" );
			menuDown = CreatePlayerAction( "menuDown" );

			dance = CreatePlayerAction("select");
		}

		public bool HasPressedMenuRight() {
			return (right.IsPressed && right.Value > 0.4f) || (menuRight.IsPressed && menuRight.Value > 0.4f);
		}

		public bool HasPressedMenuUp() {
			return (up.IsPressed && up.Value > 0.4f) || (menuUp.IsPressed && menuUp.Value > 0.4f);
		}

		public bool HasPressedMenuLeft() {
			return (left.IsPressed && left.Value > 0.4f) || (menuLeft.IsPressed && menuLeft.Value > 0.4f);
		}

		public bool HasPressedMenuDown() {
			return (down.IsPressed && down.Value > 0.4f) || (menuDown.IsPressed && menuDown.Value > 0.4f);
		}

		public bool HasReleasedMenuButtons() {
			return down.Value == 0 && up.Value == 0 && right.Value == 0 && left.Value == 0 &&
			menuDown.Value == 0 &&menuUp.Value == 0 && menuRight.Value == 0 && menuLeft.Value == 0;
		}
	}
}