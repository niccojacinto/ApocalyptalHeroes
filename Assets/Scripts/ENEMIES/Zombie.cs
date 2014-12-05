using UnityEngine;
using System.Collections;

public class Zombie : Enemy {
	void Awake()
	{
		VAwake ();
		speed = Random.Range(0.3F,0.7F);//Random.Range(50F,75F);
		knockbackMultiplier = 4;
	}
	
	void FixedUpdate()
	{
		VFixedUpdate ();
	} // void FixedUpdate()
} // public class Zombie : Enemy {
