using UnityEngine;
using System.Collections;

public class ZombieSpawn : MonoBehaviour {
	private static int bossWaveNumber = 10;
	private static int normalMobMultiplier = 26;

	public GameObject[] prefab;
	private GameObject[][] internalPrefab;

	private int currentSpawnCounter;
	private int currentWave;
	private bool bossMode;
	// Use this for initialization
	void Awake () {
		currentSpawnCounter = 0;
		currentWave = 0;

		//internalPrefab = new GameObject[] {prefab[0]};
		internalPrefab = new GameObject[][] 
		{   new GameObject[]{ prefab[0] },
			new GameObject[]{ prefab[1] },
			new GameObject[]{ prefab[2] }, 
			new GameObject[]{ prefab[3] }, 
			new GameObject[]{ prefab[4] }, 
			new GameObject[]{ prefab[0], prefab[1]},
			new GameObject[]{ prefab[2], prefab[3] }, 
			new GameObject[]{ prefab[1], prefab[3], prefab[4] }, 
			new GameObject[]{ prefab[0], prefab[1],prefab[2], prefab[3], prefab[4] },
			new GameObject[]{ prefab[5] }
		};

		Debug.Log (currentWave % internalPrefab.Length);

		bossMode = false;
		beginTheDestruction ();
	}


	void SpawnZombie () {
		Vector3 position;
		do {
			position = new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f, 1f));
			position.Normalize();
			position *= Random.Range (10,10);
		} while (position.magnitude < 5);
		/*if (currentWave % internalPrefab.Length == 2
		    || currentWave % internalPrefab.Length == 4) {
			if (Random.Range(0,2) == 0){
				return;
			}
		}*/
		Instantiate (internalPrefab [currentWave % internalPrefab.Length] 
		             [Random.Range (0, internalPrefab [currentWave % internalPrefab.Length].Length)], position, Quaternion.identity);

        currentSpawnCounter++;
		updateWave ();
	}

	void updateWave() {
		if (bossMode) {
			if (currentSpawnCounter >= (Mathf.Floor(currentWave / bossWaveNumber) + 1)) {
				CancelInvoke();
				currentSpawnCounter = 0;
				currentWave += 1;
				bossMode = false;
				beginTheDestruction(20F + (Mathf.Floor(currentWave / bossWaveNumber) + 1) * 10, 1F);
			}
		} else {
			if (currentSpawnCounter >= (Mathf.Floor(currentWave / bossWaveNumber) + 1) * normalMobMultiplier) {
				currentSpawnCounter = 0;
				currentWave += 1;
				if ((currentWave + 1) % bossWaveNumber == 0) {
					bossMode = true;
				}

				CancelInvoke();
				if (currentWave % internalPrefab.Length == 2
				     ||  currentWave % internalPrefab.Length == 4)
				{
					beginTheDestruction(0, 2.5F);
				} else {
					beginTheDestruction();
				}
			}
		} // else
	} //void updateWave() {

	void beginTheDestruction(float initialTime = 0, float repeatingTime = 1F) {
		InvokeRepeating ("SpawnZombie", initialTime, repeatingTime);
	}
}
