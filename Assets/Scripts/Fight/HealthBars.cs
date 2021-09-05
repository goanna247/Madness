using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour {
	
	[SerializeField]
	private Image playerSailHealth, playerShipHealth, playerCrewHealth, playerCannonHealth;

	[SerializeField]
	private Image enemySailHealth, enemyShipHealth, enemyCrewHealth, enemyCannonHealth;

	public void DisplaySailStats(float healthValue) {
		healthValue /= 100f;
		playerSailHealth.fillAmount = healthValue;
		// Debug.Log("you alive bro");
		// Debug.Log(healthValue);
	}

	public void DisplayShipStats(float healthValue) {
		healthValue /= 100f;
		playerShipHealth.fillAmount = healthValue;
	}

	public void DisplayCrewStats(float healthValue) {
		healthValue /= 100f;
		playerCrewHealth.fillAmount = healthValue;
	}

	public void DisplayCannonStats(float healthValue) {
		healthValue /= 100f;
		playerCannonHealth.fillAmount = healthValue;
	}



	public void DisplayEnemySail(float healthValue) {
		healthValue /= 100f;
		enemySailHealth.fillAmount = healthValue;
	}

	public void DisplayEnemyShip(float healthValue) {
		healthValue /= 100f;
		enemyShipHealth.fillAmount = healthValue;
	}

	public void DisplayEnemyCrew(float healthValue) {
		healthValue /= 100f;
		enemyCrewHealth.fillAmount = healthValue;
	}

	public void DisplayEnemyCannon(float healthValue) {
		healthValue /= 100f;
		enemyCannonHealth.fillAmount = healthValue;
	}
}