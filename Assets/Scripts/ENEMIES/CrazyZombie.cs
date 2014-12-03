using UnityEngine;

public class CrazyZombie : Enemy {
	void Awake()
	{
		VAwake ();
		speed = 3.0f;
	}
	
	void FixedUpdate()
	{
		VFixedUpdate ();
	} // void FixedUpdate()

	override protected void Knockback(BulletController other)
	{
		speed += 5f;
	}

	override protected void GetHit(BulletController bullet) {
		base.GetHit (bullet);
	}
} // public class Zombie : Enemy {
