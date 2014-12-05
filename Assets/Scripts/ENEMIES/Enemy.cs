using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject[] drop;
	public float health;
	public GameObject player;

	protected float speed;
	protected float knockbackMultiplier;
	public bool isAttacking;
	void Awake()
	{
		player = GameObject.Find("Player");
		isAttacking = true;

		InvokeRepeating ("updateMovement", 0, 0.3F);
	} // void Awake()

	// Is called by Animation Event at end of ZombieDead animation
	protected void DeleteObject()
	{
		//drop an item.
		GameObject item = Instantiate(drop[Random.Range(0,drop.Length)], transform.position, Quaternion.identity) as GameObject;
		item.GetComponent<ItemController>().Amount = 10;
		if (GetComponent<Shooter> () != null) {
			GetComponent<Shooter> ().Destroy ();
		}
		Destroy (this.gameObject);
	} // void DeleteObject()
	
	void Die()
	{
		CancelInvoke ();
		rigidbody2D.velocity = Vector2.zero;
		collider2D.enabled = false; 
		player.GetComponent<PlayerController>().playOneShot(GetComponent<AudioSource> ().clip);
		GetComponent<Animator> ().SetBool ("IsDead", true);
	} // void Die()

	void FixedUpdate()
	{
		if (IsAlive()) {
			//HandleMovement ();
		}
	} // void FixedUpdate()

	protected void updateMovement(){
		float rotz = Mathf.Atan2 ((player.transform.position.y - transform.position.y),
		                          (player.transform.position.x - transform.position.x)) *
			Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3(0, 0, rotz);

		rigidbody2D.velocity = gameObject.transform.up * speed;
	}

	void HandleMovement()
	{
		float rotz = Mathf.Atan2 ((player.transform.position.y - transform.position.y),
		                          (player.transform.position.x - transform.position.x)) *
			Mathf.Rad2Deg - 90;
		
		transform.eulerAngles = new Vector3(0, 0, rotz);
		rigidbody2D.AddForce(gameObject.transform.up.normalized * speed);
	}

	public bool IsAlive()
	{
		return health > 0;
	} // public bool IsAlive()

	protected virtual void Knockback(BulletController other)
	{
		/*float rotz = Mathf.Atan2 ((other.transform.position.y - transform.position.y),
		                          (other.transform.position.x - transform.position.x)) *
			Mathf.Rad2Deg - 90;
		
		transform.eulerAngles = new Vector3(0, 0, rotz);
		rigidbody2D.AddForce(gameObject.transform.up * (-other.Knockback * knockbackMultiplier));
			// Debug.Log("knockedback!");
		*/
	} // void Knockback(BulletController other)
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet" && IsAlive() && other.gameObject.GetComponent<BulletController> ().IsActive) {
			BulletController bullet = other.gameObject.GetComponent<BulletController>();
			GetHit(bullet);
		} // if (other.tag == "Bullet") {

	} // void OnTriggerEnter2D(Collider2D other)
	
	protected virtual void GetHit(BulletController bullet) {
		if ((health -= bullet.Damage) <= 0)
		{
			Die ();
		}//if ((health -= bullet.Damage) <= 0)
		else
		{
			Knockback(bullet);
		} // else
		bullet.Deactivate();
	}

	protected virtual void VAwake () {
		Awake ();
	}

	protected virtual void VFixedUpdate() {
		FixedUpdate ();
	}


}
