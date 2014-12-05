using UnityEngine;
using System.Collections;

public class DaylightWalkerZombie : Zombie {

	void Awake()
	{
		VAwake ();
		speed = Random.Range(25F,40F);//Random.Range(50F,75F);
	}
	
	void FixedUpdate()
	{
		VFixedUpdate ();
	} // void FixedUpdate()
}
