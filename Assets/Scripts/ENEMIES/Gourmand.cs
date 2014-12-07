using UnityEngine;
using System.Collections;

public class Gourmand : Zombie {
	private static float trueSpeed = 0.3F;
	void Awake()
	{
		VAwake ();
		speed = trueSpeed;//Random.Range(50F,75F);
	}
	
	void FixedUpdate()
	{
		VFixedUpdate ();
	} // void FixedUpdate()

	override protected void Knockback(BulletController other)
	{
		transform.localScale += new Vector3 (0.15f, 0.15f, 0f);
	}
}
