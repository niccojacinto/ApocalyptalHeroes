using UnityEngine;
using System.Collections.Generic;

public class BulletPool : ScriptableObject {

	// Private fields
	private List<BulletController> bullet;
	private uint size;

	public void Initialize(int size, GameObject bulletPrefab, float bulletDamage, float bulletKnockback, float bulletSpeed){
		bullet = new List<BulletController>();
		for (uint bulletIndex = 0; bulletIndex < size; bulletIndex++) {
			GameObject freshBullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			BulletController bulletController = freshBullet.GetComponent<BulletController>();
			bulletController.Initialize(bulletDamage, bulletKnockback, bulletSpeed);
			bullet.Add(bulletController);
		}// for (uint bulletIndex = 0; bulletIndex < size; bulletIndex++)
		this.size = (uint)size;
	}// public void initialize(int size, GameObject bulletPrefab, float bulletSpeed)

	public void ActivateBullet(Vector3 startingPosition, Vector3 targetPosition){
		for (int bulletIndex = 0; bulletIndex < size; bulletIndex++) {
			if (!bullet[bulletIndex].IsActive){
				bullet[bulletIndex].Activate(startingPosition, targetPosition);
				return;
			}// if (!bullet[bulletIndex].IsActive)
		}// for (uint bulletIndex = 0; bulletIndex < size; bulletIndex++)
	}// public void activateBullet(Vector3 startingPosition, Vector3 targetPosition)
}// public class BulletPool : MonoBehaviou	
