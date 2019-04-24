using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienUIManager : MonoBehaviour {

	public Color collectedColor, allCollectedColor;
	public List<AlienUIComponent> uiComponents;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnExplodeUnlocked() {
		uiComponents.FindAll(uiComponent => uiComponent.isCollected).
			ForEach(uiComponent => uiComponent.SetColor(Color.green));
		collectedColor = allCollectedColor;
	}

	public void OnEnemyHit(AlienTargetType alienTargetType) {
		AlienUIComponent uiComp = uiComponents.Find(uiComponent =>
			uiComponent.alienTargetType == alienTargetType && 
			!uiComponent.isCollected
		);
		uiComp.SetColor(collectedColor);
		uiComp.isCollected = true;
	}
}
