using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;

public class PlayerInputHelper {

	private static Dictionary<int, PlayerInputActions> playerInputActionsByIndex = new Dictionary<int, PlayerInputActions> ();

	public static PlayerInputActions LoadData(int playerIndex) {

		return new PlayerInputActions();
	}
		
	public static void ResetInputHelper() {
		for(int i = 0 ; i < 2; i++) { //TODO: 2p max for now
			ResetInputHelper(i);
		}
	}

	public static void ResetInputHelper(int playerIndex) {
		PlayerInputActions playerInputActions = null;
		if (playerInputActionsByIndex.ContainsKey(playerIndex)) {
			playerInputActionsByIndex.TryGetValue(playerIndex, out playerInputActions);
		}

		playerInputActionsByIndex.Remove(playerIndex);
		playerInputActions = null;
	}
}
