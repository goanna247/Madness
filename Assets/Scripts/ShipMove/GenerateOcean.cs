using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateOcean : MonoBehaviour {

	[SerializeField]
	private GameObject ship;

	private float shipXpos, shipYpos, shipZpos;
	private float originY, originX, originZ;

	private float sizeY, sizeX, sizeZ;

	private bool moveOcean = false;
	private bool lockOcean = false;

	private int moveNum;

	void Start() {
		originX = ship.transform.position.x;
		originY = ship.transform.position.y;
		originZ = ship.transform.position.z;

		sizeX = GetComponent<Renderer>().bounds.size.x;
		sizeY = GetComponent<Renderer>().bounds.size.y;
		sizeZ = GetComponent<Renderer>().bounds.size.z;

		moveNum = 1;
	}

	void Update() {
		Debug.Log(sizeZ);
		Debug.Log(shipZpos);
		shipXpos = ship.transform.position.x;
		shipYpos = ship.transform.position.y;
		shipZpos = ship.transform.position.z;

		if (((sizeZ/2)*moveNum) -10 < shipZpos) {
			moveOcean = true;
		}

		if (moveOcean) {
			moveNum ++;
			transform.position += new Vector3(0, 0, sizeZ/2);
			moveOcean = false;
		}
	}
}