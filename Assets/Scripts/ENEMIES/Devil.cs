using UnityEngine;
using System.Collections;

public class Devil : Zombie {
	private static float trueSpeed = 2.5F;

	private bool chilling;
	private float chillTime;
	void Awake()
	{
		VAwake ();
		speed = trueSpeed;//Random.Range(50F,75F);
		chilling = false;
	}
	
	void FixedUpdate()
	{
		VFixedUpdate ();
		if (chilling) {
			chillTime -= Time.deltaTime;
			chilling = chillTime > 0;
		} else if ((player.transform.position - transform.position).sqrMagnitude < 77 
		    && GetComponent<Shooter>().timeSinceLastAttack > 2.5) {
			isAttacking = true;
			speed = 0F;
			chilling = true;
			chillTime = 2F;
		} else {
			isAttacking = false;
			speed = trueSpeed;
		}
	} // void FixedUpdate()

	override protected void Knockback(BulletController other)
	{
	}
	
	override protected void GetHit(BulletController bullet) {
		base.GetHit (bullet);
	}
}
