using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Object : MonoBehaviour {
	Ray ray;
	RaycastHit hit;
	private string objectSelected = "";

	[SerializeField] private GameObject sailHighlight;
	[SerializeField] private GameObject cannonHighlight;
	[SerializeField] private GameObject pirateHighlight;
	[SerializeField] private GameObject shipHighlight;
	Renderer sailRenderer;

	void Start() {
		sailRenderer = sailHighlight.GetComponent<Renderer>();
	}

	void Update() {
		// Globals.selectedShipPiece = objectSelected;
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		// Debug.Log(ray);
		if (Physics.Raycast(ray, out hit)) {
			// Debug.Log(Physics.Raycast(ray, out hit));
			if (Input.GetMouseButtonDown(0)) {
				objectSelected = hit.collider.name;
				// Debug.Log(objectSelected);

				if (objectSelected == "SailHighlight" || objectSelected == "CannonHighlight" || objectSelected == "PirateHighlight" || objectSelected == "EnemyShip") {
					Globals.selectedShipPiece = objectSelected;
				} else if (objectSelected == "Plane") {

				}
			}
		}

		if (objectSelected == "SailHighlight") {
			sailHighlight.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 0.2f);
		} else {
			sailHighlight.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 0.0f);
		}

		if (objectSelected == "CannonHighlight") {
			cannonHighlight.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 0.2f);
		} else {
			cannonHighlight.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 0.0f);
		}

		if (objectSelected == "PirateHighlight") {
			pirateHighlight.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 0.2f);
		} else {
			pirateHighlight.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 0.0f);
		}

		if (objectSelected == "EnemyShip") {
			shipHighlight.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 0.2f);
		} else {
			shipHighlight.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 0.0f);
		}
	}
}
