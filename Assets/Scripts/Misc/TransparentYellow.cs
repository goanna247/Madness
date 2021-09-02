using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransparentYellow : MonoBehaviour {
	void Start() {
		gameObject.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 0.0f, 0.2f);
	}
}