using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FightButton : MonoBehaviour {
	
	[SerializeField] private Button shoot;
	[SerializeField] private Button blast;
	[SerializeField] private Button runAway;
	// [SerializeField] private Button winReturn;
	// [SerializeField] private Button lossReturn

	[SerializeField] private Text bullets;
	[SerializeField] private Text cannons;

	public int bulletsLeft;
	public int cannonsLeft;

	public void Start() {
		bulletsLeft = Globals.bullets;
		cannonsLeft = Globals.cannonBalls;
		Debug.Log(bulletsLeft);
		Debug.Log(cannonsLeft);
	}

	public void Update() {
		Globals.cannonBalls = cannonsLeft;
		Globals.bullets = bulletsLeft;

		bullets.text = bulletsLeft.ToString();
		cannons.text = cannonsLeft.ToString();
	}

	public void Shoot() {
		Debug.Log("SHOOOOOOT");
		if (bulletsLeft > 0) {
			bulletsLeft --;
		} 
	}

	public void Blast() {
		Debug.Log("BLASTTTT");
		if (cannonsLeft > 0) {
			cannonsLeft --;
		}
	}

	public void RunAway() {
		//display you have run away message;
		SceneManager.LoadScene("NormalSea");
	}

	public void Return() {
		//enable later when we arent testing @TODO Anna
		SceneManager.LoadScene("NormalSea");
	}
}