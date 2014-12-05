using UnityEngine;

public class CrazyZombie : Enemy {
	private static float trueSpeed = 20F;
	void Awake()
	{
		VAwake ();
		speed = trueSpeed;
	}
	
	void FixedUpdate()
	{
		VFixedUpdate ();

	} // void FixedUpdate()

	override protected void Knockback(BulletController other)
	{
		if (speed <= 130f) {
			speed += 20f;
		}
	}

	override protected void GetHit(BulletController bullet) {
		base.GetHit (bullet);
	}
} // public class Zombie : Enemy {
