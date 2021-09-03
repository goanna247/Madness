using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MoveWithShip : MonoBehaviour {
	
	void Start() {
		// transform.position = new Vector3(1,1,0);
	}

	void Update() {
		transform.position += new Vector3(0, 0, 3 * Time.deltaTime);
	}
}