using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyShip : MonoBehaviour {

	public string objectSelected = "";

	void Start() {

	}

	void Update() {
		objectSelected = Globals.selectedShipPiece;
		// Debug.Log(objectSelected);
	}
}