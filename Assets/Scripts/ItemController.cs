using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {
	public enum ItemType {AMMO, COPPER, METAL, WOOD};

	public ItemType type;

	private float expiryTimer;
	private bool expire;
	int amount;
	// Use this for initialization
	void Start () {
		expire = true;
		expiryTimer = 6f;
	}
	
	// Update is called once per frame
	void Update () {
		if (expire) {
			expiryTimer -= Time.deltaTime;
			if (expiryTimer < 0) {
					StartLootAnim ();
			}
		}
	}

	void HandleLoot(PlayerController player) {
		StartLootAnim ();
		player.giveItem (type, amount);
	}

	private void StartLootAnim() {
		expire = false;
		Animator anim = GetComponent<Animator> ();
		anim.SetBool ("IsLooted", true);
	}

	void EndOfLootAnimation() {
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			collider2D.enabled = false;
			HandleLoot(other.gameObject.GetComponent<PlayerController>());
		}
	}


	public int Amount { 
		get { return amount; }
		set { amount = value; }
	} 
}
