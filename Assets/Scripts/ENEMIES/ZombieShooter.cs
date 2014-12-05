using UnityEngine;

public class ZombieShooter : Shooter {
	void Start () {
		base.VStart ();
	} // void Start () {
	
	void Update () {
		timeSinceLastAttack += Time.deltaTime;
		Shoot ();
	}// void Update ()
	
	override protected void Shoot() {
		if (timeSinceLastAttack > repeatTime && GetComponent<Enemy>().isAttacking) {
			//Debug.Log("Shoot a bullet!");
			bulletPool.ActivateBullet (transform.position, GetComponent<Enemy>().player.transform.position);
			Vector3 newVector = new Vector3(GetComponent<Enemy>().player.transform.position.x, GetComponent<Enemy>().player.transform.position.y);
			Vector3 perpendicular = new Vector3(GetComponent<Enemy>().player.transform.position.y, -GetComponent<Enemy>().player.transform.position.x);

			bulletPool.ActivateBullet (transform.position, Vector3.RotateTowards(newVector,perpendicular, 1,0));
			bulletPool.ActivateBullet (transform.position, Vector3.RotateTowards(newVector,perpendicular, -1,0));
			timeSinceLastAttack = 0;
		}// if (Input.GetMouseButtonDown() && timeSinceLastAttack > repeatTime) {
	} // override protected void Shoot() {
} // public class MouseShooter : MonoBehaviour
