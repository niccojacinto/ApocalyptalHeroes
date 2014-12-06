using UnityEngine;
using System.Collections;

public class SpitZombie : Zombie {
	private static float trueSpeed = 0.9F;
	void Awake()
	{
		VAwake ();
		speed = trueSpeed;//Random.Range(50F,75F);

		CancelInvoke ();
		InvokeRepeating ("updateMovement", 0, 0.5F);
		InvokeRepeating ("DetectPlayer", 0, 0.5F);
	}
	
	void FixedUpdate()
	{
		VFixedUpdate ();

	} // void FixedUpdate()

	void DetectPlayer(){
		if ((player.transform.position - transform.position).sqrMagnitude < 37) {
			speed = 0F;
			isAttacking = true;
		} else {
			speed = trueSpeed;
			isAttacking = false;
		}
	}

	override protected void Knockback(BulletController other)
	{
	}
}
