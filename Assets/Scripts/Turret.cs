using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public float minDistance;
	public float scanFrequency;
	public Enemy target;
	private GameObject[] allEnemies;

	void Awake()
	{
		InvokeRepeating("ScanSurround", 0, scanFrequency);
	}

	void FixedUpdate()
	{
		HandleRotation ();
	}

	void HandleRotation()
	{
		if (target != null) {
			float rotz = Mathf.Atan2 ((target.transform.position.y - transform.position.y),
                  (target.transform.position.x - transform.position.x)) *
					Mathf.Rad2Deg - 90;

			transform.eulerAngles = new Vector3 (0, 0, rotz);
		}
	}

	void ScanSurround()
	{
		allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (GameObject enemy in allEnemies) {
			if (enemy.GetComponent<Enemy>().IsAlive()) {
				Vector3 difference = (enemy.transform.position - transform.position);
				float distance = difference.sqrMagnitude;

				if (distance <= minDistance) {
						target = enemy.GetComponent<Enemy> ();
				}
			} // if (enemy.GetComponent<Enemy> ().IsAlive())
		}

	}
}
