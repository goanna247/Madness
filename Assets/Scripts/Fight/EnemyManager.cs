using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

	public static EnemyManager instance;

	[SerializeField]
	private GameObject piratePrefab;

	public Transform[] pirateSpawnPoints;

	[SerializeField]
	private int pirateShipCount;
	private int initialPirateCount;

	public float waitBeforeSpawnEnemiesTime = 5f;

	void Awake() {
		MakeInstance();
	}

	void Start() {
		initialPirateCount = pirateShipCount;
		SpawnEnemies();
		StartCoroutine("CheckToSpawnEnemies");
	}

	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
	}

	void SpawnEnemies() {
		SpawnPirates();
	}

	void SpawnPirates() {
		Debug.Log("Omg entering the loop pog");
		int index = 0;

		for (int i = 0; i < pirateShipCount; i++) {
			if (index >= pirateSpawnPoints.Length) {
				index = 0;
			}

			Instantiate(piratePrefab, pirateSpawnPoints[index].position, Quaternion.identity);

			index++;
		}
		pirateShipCount = 0;
	}

	IEnumerator CheckToSpawnEnemies() {
		yield return new WaitForSeconds(waitBeforeSpawnEnemiesTime);
		SpawnPirates();
		StartCoroutine("CheckToSpawnEnemies");
	}

	public void EnemyDied() {
		pirateShipCount++;
		if (pirateShipCount >  initialPirateCount) {
			pirateShipCount = initialPirateCount;
		}
	}

	public void StopSpawning() {
		StopCoroutine("CheckToSpawnEnemies");
	}
}