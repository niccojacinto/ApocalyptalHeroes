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
		if (Input.GetMouseButton(0) && timeSinceLastAttack > repeatTime) {
			audio.PlayOneShot(GetComponent<AudioSource>().clip);
			//Debug.Log("Shoot a bullet!");
			bulletPool.ActivateBullet (transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
			timeSinceLastAttack = 0;
		}// if (Input.GetMouseButtonDown() && timeSinceLastAttack > repeatTime) {
	} // override protected void Shoot() {
} // public class MouseShooter : MonoBehaviour
