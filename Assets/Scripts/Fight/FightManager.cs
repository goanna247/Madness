using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FightManager : MonoBehaviour {

	// enum shipPartGens {SAILS, CREW, SHIP, CANNONS};

	[SerializeField] private Button shoot;
	[SerializeField] private Button blast;
	[SerializeField] private Button runAway;

	int blastOrShoot;
	int shipPartGen;

	[SerializeField] private HealthBars healthBars;

	public bool playerTurn = true;
	private bool shot;

	public bool Victory = false;
	public bool Loss = false;

	//victory message 
	[SerializeField] private Image victoryMessage;
	[SerializeField] private Image victoryText;
	[SerializeField] private Image apples; //am i right chat
	[SerializeField] private Image meat;
	[SerializeField] private Image bullets;
	[SerializeField] private Image balls;
	[SerializeField] private Text applesText;
	[SerializeField] private Text meatText;
	[SerializeField] private Text ballsText;
	[SerializeField] private Text bulletsText;
	[SerializeField] private Button returnButton;
	[SerializeField] private Image returnText;

	//loss message
	[SerializeField] private Image lossMessage;
	[SerializeField] private Image losstext; //its actually an image not text, ha get pranked
	[SerializeField] private Button returnButtonTwo; //electric boogaloo
	[SerializeField] private Image returnTextTwo; //electric boogaloo

	private int appleLoot;
	private int meatLoot;
	private int cannonLoot;
	private int bulletLoot;

	private bool generatedLoot;

	void Start() {
		generatedLoot = false;
	}

	void Update() {
		healthBars.DisplaySailStats(Globals.PlayerSailHealthVar);
		healthBars.DisplayShipStats(Globals.PlayerShipHealthVar);
		healthBars.DisplayCrewStats(Globals.PlayerCrewHealthVar);
		healthBars.DisplayCannonStats(Globals.PlayerCannonHealthVar);

		healthBars.DisplayEnemyCrew(Globals.PirateCrewHealthVar);
		healthBars.DisplayEnemySail(Globals.PirateSailHealthVar);
		healthBars.DisplayEnemyShip(Globals.PirateShipHealthVar);
		healthBars.DisplayEnemyCannon(Globals.PirateCannonHealthVar);

		if (Globals.PirateSailHealthVar > 0 && Globals.PirateShipHealthVar > 0 && Globals.PirateCrewHealthVar > 0 && Globals.PirateCannonHealthVar > 0) {
			if (playerTurn) {
				PlayersTurn();
				// Debug.Log(Globals.selectedShipPiece);
			} else {
				PirateTurn();
			}
			Victory = false;
		} else {
			// Debug.Log("VICTORY");
			shoot.interactable = false;
			blast.interactable = false;
			Victory = true;
		}

		if (Globals.PlayerCrewHealthVar <= 0 || Globals.PlayerSailHealthVar <= 0 || Globals.PlayerShipHealthVar <= 0 || Globals.PlayerCannonHealthVar <= 0) {
			Loss = true;
		} else {
			Loss = false;
		}

		if (Victory) {
			if (!generatedLoot) {
				GenerateLoot();
			}
			applesText.text = appleLoot.ToString();
			meatText.text = meatLoot.ToString();
			ballsText.text = cannonLoot.ToString();
			bulletsText.text = bulletLoot.ToString();

			victoryMessage.enabled = true;
			victoryText.enabled = true;
			apples.enabled = true;
			meat.enabled = true;
			balls.enabled = true; //enable deez nuts
			bullets.enabled = true;
			returnText.enabled = true;

			applesText.enabled = true;
			meatText.enabled = true;
			ballsText.enabled = true;
			bulletsText.enabled = true;

			returnButton.gameObject.SetActive(true);

		} else {
			victoryMessage.enabled = false;
			victoryText.enabled = false;
			apples.enabled = false;
			meat.enabled = false;
			balls.enabled = false; //enable deez nuts
			bullets.enabled = false;
			returnText.enabled = false;

			applesText.enabled = false;
			meatText.enabled = false;
			ballsText.enabled = false;
			bulletsText.enabled = false;

			returnButton.gameObject.SetActive(false);
		}

		if (Loss) {
			lossMessage.enabled = true;
			losstext.enabled = true;
			returnTextTwo.enabled = true;

			returnButtonTwo.gameObject.SetActive(true);
		} else {
			lossMessage.enabled = false;
			losstext.enabled = false;
			returnTextTwo.enabled = false;

			returnButtonTwo.gameObject.SetActive(false);
		}

		// Debug.Log(playerTurn);
	}


	private void PlayersTurn() {
		shot = false;
		if (Globals.selectedShipPiece == "CannonHighlight" || Globals.selectedShipPiece == "SailHighlight" || Globals.selectedShipPiece == "EnemyShip" || Globals.selectedShipPiece == "PirateHighlight") {
			if (Globals.cannonBalls > 0) {
				blast.interactable = true;
				blast.enabled = true;
			} else {
				blast.interactable = false;
			}

			if (Globals.bullets > 0) {
				shoot.interactable = true;
				shoot.enabled = true;
			} else {
				shoot.interactable = false;
			}
			

		} else {
			shoot.interactable = false;
			blast.interactable = false;
		}


		// if (shoot.onClick) {
		// Debug.Log("Player Turn over");

		// 	playerTurn = true;
		// } else if (blast.onClick) {
		// 	Debug.Log("Player Turn over");
		// 	playerTurn = true;
		// }

		shoot.onClick.AddListener(PlayerShoot); //ikr a function without ()
		blast.onClick.AddListener(PlayerBlast);
	}	

	private void PirateTurn() {
		shoot.interactable = false;
		blast.interactable = false;
		blastOrShoot = Random.Range(0, 10);
		shipPartGen = Random.Range(0, 40);

		if (blastOrShoot >= 7) {
			//blast
			if (shipPartGen >= 30) {
				//hit sails
				PirateAttack(false, "Sail");
			} else if (shipPartGen >= 20 && shipPartGen < 30) {
				//hit crew
				PirateAttack(false, "Crew");
			} else if (shipPartGen >= 10 && shipPartGen < 20) {
				//hit ship
				PirateAttack(false, "Ship");
			} else if (shipPartGen >= 0 && shipPartGen < 10) {
				//hit cannons
				PirateAttack(false, "Cannons");
			}

		} else {
			//shoot 
			if (shipPartGen >= 30) {
				//hit sails
				PirateAttack(true, "Sail");
			} else if (shipPartGen >= 20 && shipPartGen < 30) {
				//hit crew
				PirateAttack(true, "Crew");
			} else if (shipPartGen >= 10 && shipPartGen < 20) {
				//hit ship
				PirateAttack(true, "Ship");
			} else if (shipPartGen >= 0 && shipPartGen < 10) {
				//hit cannons
				PirateAttack(true, "Cannons");
			}
		}
	}

	private void PirateAttack(bool shoot, string shipPart) {
		if (shoot) {
			if (shipPart == "Cannons") {
				Debug.Log("shot cannons");
				Globals.PlayerCannonHealthVar -= Globals.PirateShootDamage;
				playerTurn = true;
			} else if (shipPart == "Ship") {
				Debug.Log("shot ship");
				Globals.PlayerShipHealthVar -= Globals.PirateShootDamage;
				playerTurn = true;
			} else if (shipPart == "Crew") {
				Debug.Log("shot crew");
				Globals.PlayerCrewHealthVar -= Globals.PirateShootDamage;
				playerTurn = true;
			} else if (shipPart == "Sail") {
				Debug.Log("shot sail");
				Globals.PlayerSailHealthVar -= Globals.PirateShootDamage;
				playerTurn = true;
			}
		} else {
			if (shipPart == "Cannons") {
				Debug.Log("blast cannons");
				Globals.PlayerCannonHealthVar -= Globals.PirateBlastDamage;
				playerTurn = true;
			} else if (shipPart == "Ship") {
				Debug.Log("blast ship");
				Globals.PlayerShipHealthVar -= Globals.PirateBlastDamage;
				playerTurn = true;
			} else if (shipPart == "Crew") {
				Debug.Log("blast crew");
				Globals.PlayerCrewHealthVar -= Globals.PirateBlastDamage;
				playerTurn = true;
			} else if (shipPart == "Sail") {
				Debug.Log("blast sails");
				Globals.PlayerSailHealthVar -= Globals.PirateBlastDamage;
				playerTurn = true;
			}
		}
	}

	void playerTurnOver() {
		//display hit message
		Debug.Log("Player Turn over");
	}


	void PlayerBlast() {
		if (!shot) {
			if (Globals.selectedShipPiece == "SailHighlight") {
				Globals.PirateSailHealthVar -= Globals.PlayerBlastDamage;
				DisplayHitData(Globals.selectedShipPiece);
			} else if (Globals.selectedShipPiece == "PirateHighlight") {
				Globals.PirateShipHealthVar -= Globals.PlayerBlastDamage;
				DisplayHitData(Globals.selectedShipPiece);
			} else if (Globals.selectedShipPiece == "CannonHighlight") {
				Globals.PirateCannonHealthVar -= Globals.PlayerBlastDamage;
				DisplayHitData(Globals.selectedShipPiece);
			} else if (Globals.selectedShipPiece == "EnemyShip") {
				Globals.PirateCrewHealthVar -= Globals.PlayerBlastDamage;
				DisplayHitData(Globals.selectedShipPiece);
			}
		}
	}

	void PlayerShoot() {
		if (!shot) {
			if (Globals.selectedShipPiece == "SailHighlight") {
				Globals.PirateSailHealthVar -= Globals.PlayerShootDamage;
				DisplayHitData(Globals.selectedShipPiece);
			} else if (Globals.selectedShipPiece == "PirateHighlight") {
				Globals.PirateCrewHealthVar -= Globals.PlayerShootDamage;
				DisplayHitData(Globals.selectedShipPiece);
			} else if (Globals.selectedShipPiece == "CannonHighlight") {
				Globals.PirateCannonHealthVar -= Globals.PlayerShootDamage;
				DisplayHitData(Globals.selectedShipPiece);
			} else if (Globals.selectedShipPiece == "EnemyShip") {
				Globals.PirateShipHealthVar -= Globals.PlayerShootDamage;
				DisplayHitData(Globals.selectedShipPiece);
			}
		}
	}

	private void DisplayHitData(string location) {
		Debug.Log(Globals.PirateSailHealthVar);
		shot = true;
		playerTurn = false;
	}

	private void GenerateLoot() {
		appleLoot = Mathf.FloorToInt(2.1f * Globals.PlayerLevel * Random.Range(1f, 2f)); //0.8 is the apple coefficient * (float)Random.Range(0.4, 1.2)
		meatLoot = Mathf.FloorToInt(1.2f * Globals.PlayerLevel * Random.Range(1f, 2f)); //* (float)Random.Range(0.5, 2)
		bulletLoot = Mathf.FloorToInt(3.4f * Globals.PlayerLevel * Random.Range(1.2f, 2f)); //* (float)Random.Range(1.2, 2)
		cannonLoot = Mathf.FloorToInt(2.2f * Globals.PlayerLevel * Random.Range(1.2f, 2.1f)); //* (float)Random.Range(1.2, 2.1)
		generatedLoot = true;
	}
}