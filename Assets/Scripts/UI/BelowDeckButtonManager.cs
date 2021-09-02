using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BelowDeckButtonManager : MonoBehaviour {
	
	[SerializeField]
	private Button returnButton;

	void Start() {

	}

	public void BackButton() {
		SceneManager.LoadScene("NormalSea");
	}
}