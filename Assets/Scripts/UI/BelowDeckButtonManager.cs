using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class BelowDeckButtonManager : MonoBehaviour {

	[SerializeField] private Button returnButton;

	[SerializeField] private Button applesButton;
	[SerializeField] private Button meatButton;

	[SerializeField] private Text applesText;
	[SerializeField] private Text meatText;
	[SerializeField] private Text crewNumber;
	[SerializeField] private Text cannonNumber;
	[SerializeField] private Text gunNumber;

	void Start() {
		if (Globals.PlayerCannonHealthVar < 100 || Globals.PlayerCrewHealthVar < 100 || Globals.PlayerSailHealthVar < 100 || Globals.PlayerShipHealthVar < 100) {
			applesButton.interactable = true;
			meatButton.interactable = true;
		} else {
			applesButton.interactable = false;
			meatButton.interactable = false;
		}
	}

	void Update() {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;

		applesText.text = Globals.apples.ToString();
		meatText.text = Globals.meat.ToString();
		cannonNumber.text = Globals.cannonBalls.ToString();
		gunNumber.text = Globals.bullets.ToString();
		crewNumber.text = "5"; //lol variable who
	}

	public void BackButton() {
		SceneManager.LoadScene("NormalSea");
	}

	public void EatApple() {
		Globals.apples --;
		if (Globals.PlayerCrewHealthVar < 100) {
			Globals.PlayerCrewHealthVar += 10;
		} else if (Globals.PlayerShipHealthVar < 100) {
			Globals.PlayerShipHealthVar += 10;
		} else if (Globals.PlayerSailHealthVar < 100) {
			Globals.PlayerSailHealthVar += 10;
		} else if (Globals.PlayerCannonHealthVar < 100) {
			Globals.PlayerCannonHealthVar += 10;
		} else {
			applesButton.interactable = false;
		}
	}

	public void EatMeat() { //just to upset the vegans 
		Globals.meat --;
		if (Globals.PlayerCrewHealthVar < 100) {
			Globals.PlayerCrewHealthVar += 10;
		} else if (Globals.PlayerShipHealthVar < 100) {
			Globals.PlayerShipHealthVar += 10;
		} else if (Globals.PlayerSailHealthVar < 100) {
			Globals.PlayerSailHealthVar += 10;
		} else if (Globals.PlayerCannonHealthVar < 100) {
			Globals.PlayerCannonHealthVar += 10;
		} else {
			meatButton.interactable = false;
		}
	}
}