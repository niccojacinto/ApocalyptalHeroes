using UnityEngine;
using System.Collections;

public class ZombieSpawn : MonoBehaviour {

	public GameObject[] prefab;
	// Use this for initialization
	void Awake () {
		InvokeRepeating("SpawnZombie", 0, 2F);
	}
	
	// Update is called once per frame
	void SpawnZombie () {
		Vector3 position;
		do {
			position = new Vector3 (Random.Range (-1f, 1f), Random.Range (-1f, 1f));
			position.Normalize();
			position *= Random.Range (10,10);
		} while (position.magnitude < 5);
		Instantiate (prefab [Random.Range (0, prefab.Length)], position, Quaternion.identity);
	}
}
