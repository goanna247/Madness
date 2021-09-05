using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour {

	[SerializeField] private HealthBars healthBars;

	[SerializeField] private Text levelText;

	void Start() {

	}

	void Update() {
		levelText.text = Globals.PlayerLevel.ToString();

		healthBars.DisplaySailStats(Globals.PlayerSailHealthVar);
		healthBars.DisplayShipStats(Globals.PlayerShipHealthVar);
		healthBars.DisplayCrewStats(Globals.PlayerCrewHealthVar);
		healthBars.DisplayCannonStats(Globals.PlayerCannonHealthVar);
	}
}