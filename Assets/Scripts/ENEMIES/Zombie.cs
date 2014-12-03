using UnityEngine;
using System.Collections;

public class Zombie : Enemy {
	void Awake()
	{
		VAwake ();
		speed = Random.Range(2.5F,6.5F);
	}
	
	void FixedUpdate()
	{
		VFixedUpdate ();
	} // void FixedUpdate()
} // public class Zombie : Enemy {
