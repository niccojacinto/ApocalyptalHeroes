using UnityEngine;
using System.Collections;

public class DaylightWalkerZombie : Zombie {

	void Awake()
	{
		VAwake ();
		speed = Random.Range(0.6F,1.7F);//Random.Range(50F,75F);
		knockbackMultiplier = 2F;
	}
	
	void FixedUpdate()
	{
		VFixedUpdate ();
	} // void FixedUpdate()
}
