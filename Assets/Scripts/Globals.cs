using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Globals : MonoBehaviour {
	public static float shipSpeed = 3f; 
	public static string selectedShipPiece = "";
	public static int bullets = 10;
	public static int cannonBalls = 8;

	//player health 
	public static float PlayerSailHealthVar = 100f;
	public static float PlayerCrewHealthVar = 100f;
	public static float PlayerShipHealthVar = 100f;
	public static float PlayerCannonHealthVar = 100f;

	//Pirate health 
	public static float PirateSailHealthVar = 90f;
	public static float PirateShipHealthVar = 90f;
	public static float PirateCrewHealthVar = 90f;
	public static float PirateCannonHealthVar = 90f;

	//damage
	public static float PlayerBlastDamage = 20f;
	public static float PlayerShootDamage = 10f;

	public static float PirateBlastDamage = 15f;
	public static float PirateShootDamage = 8f;

	public static int PlayerLevel = 1;

	void Update() {
		// Debug.Log(shipSpeed);
	}
}