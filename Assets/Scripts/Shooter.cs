using UnityEngine;

public class Shooter : MonoBehaviour {
	// Public fields
	public GameObject bulletPrefab;
	public float bulletDamage;
	public float bulletKnockback;
	public float bulletSpeed;
	public float numberOfBulletsInClip;
	public float reloadTime;
	public float repeatTime;
	public int maxNumberOfBullets;
	
	protected BulletPool bulletPool;
	protected float numberOfBullets;
	public float timeSinceLastAttack;
	void Start () {
		bulletPool = ScriptableObject.CreateInstance ("BulletPool") as BulletPool;
		bulletPool.Initialize(maxNumberOfBullets, bulletPrefab, bulletDamage, bulletKnockback, bulletSpeed);
		timeSinceLastAttack = 0;
		numberOfBullets = numberOfBulletsInClip;
	} // void Start () {
	
	void Update () {
		timeSinceLastAttack += Time.deltaTime;
		if (numberOfBullets > 0) {
			Shoot ();
		} else if (timeSinceLastAttack > reloadTime) {
			numberOfBullets = numberOfBulletsInClip; 	
		}
	}// void Update ()

	protected virtual void Shoot(){
		if (GetComponent<Turret>().target != null && GetComponent<Turret>().target.IsAlive()
		    	&& timeSinceLastAttack > repeatTime) {
			audio.PlayOneShot(GetComponent<AudioSource>().clip);
			bulletPool.ActivateBullet (transform.position, GetComponent<Turret>().target.transform.position );
			timeSinceLastAttack = 0;
			numberOfBullets--;
			// Debug.Log("shot!");
		}// if (Input.GetMouseButtonDown() && timeSinceLastAttack > repeatTime) {
	}

	protected virtual void VStart () {
		Start();
	} // protected virtual void VStart () {

	public void Destroy(){
		bulletPool.DestroyBullets ();
	}
} // public class MouseShooter : MonoBehaviour
