using UnityEngine;
using System.Collections;

public class SpitZombie : Zombie {
	private static float trueSpeed = 25F;
	void Awake()
	{
		VAwake ();
		speed = trueSpeed;//Random.Range(50F,75F);
	}
	
	void FixedUpdate()
	{
		VFixedUpdate ();
		if ((player.transform.position - transform.position).sqrMagnitude < 44) {
			speed = 0F;
			isAttacking = true;
		} else {
			speed = trueSpeed;
			isAttacking = false;
		}
	} // void FixedUpdate()
}
