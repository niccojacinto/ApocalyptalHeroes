using UnityEngine;

public class MouseShooter : Shooter {
	void Start () {
		base.VStart ();
	} // void Start () {
	
	void Update () {
		timeSinceLastAttack += Time.deltaTime;
		Shoot ();
	}// void Update ()

	override protected void Shoot() {
		if (GetComponent<PlayerController>().gameMode == PlayerController.GameMode.COMBAT &&
		    Input.GetMouseButton(0) && timeSinceLastAttack > repeatTime) {
			audio.PlayOneShot(GetComponent<AudioSource>().clip);
			//Debug.Log("Shoot a bullet!");


			bulletPool.ActivateBullet (transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
			timeSinceLastAttack = 0;
		}// if (Input.GetMouseButtonDown() && timeSinceLastAttack > repeatTime) {
	} // override protected void Shoot() {

	// For use of intimate slaying of Devils
	private void DevilSlayer() {
		for (int i = 0; i < 1000; i++){
			float rndx = Random.Range(-50f, 50f) + Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
			float rndy = Random.Range(-50f, 50f) + Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
			float rndz = Camera.main.ScreenToWorldPoint(Input.mousePosition).z;
			Vector3 spread = new Vector3(rndx, rndy, rndz);
			
			bulletPool.ActivateBullet (transform.position, spread);
		}
	}

	// More useful against angels.
	private void AngelSlayer() {
		for (int i = 0; i < 20; i++){
			float rndx = Random.Range(-0.5f, 0.5f) + Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
			float rndy = Random.Range(-0.5f, 0.5f) + Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
			float rndz = Camera.main.ScreenToWorldPoint(Input.mousePosition).z;
			Vector3 spread = new Vector3(rndx, rndy, rndz);
			
			bulletPool.ActivateBullet (transform.position, spread);
		}
	}
} // public class MouseShooter : MonoBehaviour
