using UnityEngine;
using System.Collections;

public class Zombie : Enemy {
	void Awake()
	{
		VAwake ();
		speed = Random.Range(50F,75F);
	}
	
	void FixedUpdate()
	{
		VFixedUpdate ();
	} // void FixedUpdate()
} // public class Zombie : Enemy {
