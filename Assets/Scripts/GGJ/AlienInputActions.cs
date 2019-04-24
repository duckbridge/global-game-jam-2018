using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InControl {
	public class AlienInputActions : PlayerActionSet {

		public PlayerAction explode;
		public PlayerAction backTrack;
		public PlayerAction reset;

		public PlayerAction shoot;
		public PlayerAction leftStickLeft;
		public PlayerAction leftStickRight;

		public PlayerAction leftStickUp;
		public PlayerAction leftStickDown;
		
		public PlayerOneAxisAction leftStickXPosition;
		public PlayerOneAxisAction leftStickYPosition;

		// Use this for initialization
		public AlienInputActions() {

			shoot = CreatePlayerAction(" shoot ");
			explode = CreatePlayerAction(" explode ");
			reset = CreatePlayerAction(" reset ");
			leftStickLeft = CreatePlayerAction( "left" );
			leftStickRight = CreatePlayerAction( "right" );

			leftStickUp = CreatePlayerAction( "up" );
			leftStickDown = CreatePlayerAction( "down" );

			leftStickXPosition = CreateOneAxisPlayerAction( leftStickLeft, leftStickRight );
			leftStickYPosition = CreateOneAxisPlayerAction( leftStickDown, leftStickUp );
		}

		public Vector2 GetLeftAnalogPosition() {
			return new Vector2(leftStickXPosition.Value, leftStickYPosition.Value);
		}

		public static AlienInputActions CreateWithDefaultBindings()
		{
			var playerActions = new AlienInputActions();
			playerActions.leftStickUp.AddDefaultBinding( Key.UpArrow );
			playerActions.leftStickDown.AddDefaultBinding( Key.DownArrow );
			playerActions.leftStickLeft.AddDefaultBinding( Key.LeftArrow );
			playerActions.leftStickRight.AddDefaultBinding( Key.RightArrow );
			playerActions.reset.AddDefaultBinding(Key.Escape);
			playerActions.shoot.AddDefaultBinding(Key.D);
			playerActions.explode.AddDefaultBinding(Key.E);
			
			playerActions.leftStickLeft.AddDefaultBinding( InputControlType.LeftStickLeft );
			playerActions.leftStickRight.AddDefaultBinding( InputControlType.LeftStickRight );
			playerActions.leftStickUp.AddDefaultBinding( InputControlType.LeftStickUp );
			playerActions.leftStickDown.AddDefaultBinding( InputControlType.LeftStickDown );
			playerActions.reset.AddDefaultBinding(InputControlType.Action5);
			playerActions.shoot.AddDefaultBinding(InputControlType.Action1);
			playerActions.explode.AddDefaultBinding(InputControlType.Action2);

			return playerActions;
		}
	}
}