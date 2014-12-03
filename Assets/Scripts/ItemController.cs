using UnityEngine;
using System.Collections;

public class ItemController : MonoBehaviour {
	public enum ItemType {AMMO, COPPER, METAL, WOOD};

	public ItemType type;

	int amount;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void HandleLoot(PlayerController player) {
		Animator anim = GetComponent<Animator> ();
		anim.SetBool ("IsLooted", true);

		player.giveItem (type, amount);
	}

	void EndOfLootAnimation() {
		Destroy (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			HandleLoot(other.gameObject.GetComponent<PlayerController>());
		}
	}


	public int Amount { 
		get { return amount; }
		set { amount = value; }
	} 
}
