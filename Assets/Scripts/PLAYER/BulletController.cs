using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {
	// Private fields
	private bool isActive;
	private float damage;
	private float knockback;
	private float moveSpeed;

	protected void Start () {
		isActive = false;
		renderer.enabled = false;
	} // void Start () {
	
	void Update () {
	}// void Update ()

	public void Activate(Vector3 startingPosition, Vector3 targetPosition) {
		transform.position = startingPosition;
		Vector3 difference = targetPosition - transform.position;
		difference.Normalize();

		/*Set bullet speed*/
		Vector2 speed = new Vector2 (difference.x, difference.y);
		rigidbody2D.velocity = speed.normalized * moveSpeed;

		/*Set bullet rotation*/
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, rotZ-90);

		isActive = true;
		GetComponent<CircleCollider2D> ().enabled = true;
		renderer.enabled = true;
	}// public void ActivateBullet(Vector3 startingPosition, Vector3 targetPosition)



	public void Deactivate() {
		isActive = false;
		renderer.enabled = false;
		GetComponent<CircleCollider2D> ().enabled = false;
		rigidbody2D.velocity = Vector2.zero;
	}// public DeactivateBullet(

	public float Damage {
		get {return damage;}
	}


	public bool IsActive { 
		get {return isActive;}
	}// public bool IsActive{

	public void Initialize(float damage, float knockback, float speed) {
		this.damage = damage;
		this.knockback = knockback;
		moveSpeed = speed;
	}// public void SetSpeed(float speed)

	public float Knockback {
		get {return knockback;}
	}

	public void OnBecameInvisible() {
		//Debug.Log ("I am disabled!");
		Deactivate();
	}// public void OnBecameInvisible()
} //public class BulletController : MonoBehaviour {
