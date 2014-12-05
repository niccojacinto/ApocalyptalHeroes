using UnityEngine;

public class CrazyZombie : Enemy {
	private static float trueSpeed = 0.5F;
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
		if (speed <= 6f) {
			speed += 1f;
			updateMovement();
		}
	}

	override protected void GetHit(BulletController bullet) {
		base.GetHit (bullet);
	}
} // public class Zombie : Enemy {
