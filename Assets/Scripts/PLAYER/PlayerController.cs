using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int lives;
	public int ammo;
	public int metal;
	public int wood;
	public int copper;

	public float speed = 3.0f;

	public Weapon weapon;
	public GameMode gameMode;

	public enum GameMode {COMBAT, CONSTRUCT}
	public enum Weapon {PISTOL, MACHINEGUN}

    public GameObject constructPanel;

	void Awake()
	{
		gameMode = GameMode.COMBAT;
        constructPanel = GameObject.Find("ConstructPanel");
	}

    void Update()
    {
        HandleInput();
        // var x = transform.position.x + 0.5;
        // var y = transform.position.y + 0.5;

        // Debug.Log("("+(int)x + ", " + (int)y+")");

    }

	void FixedUpdate()
	{
		HandleAnimation ();
		HandleRotation ();
		HandleMovement ();
		HandleScreenBoundary ();
	}

	void HandleAnimation()
	{
		//Animator anim = GetComponent<Animator> ();
		// anim.SetBool ("IsMoving", rigidbody2D.velocity != Vector2.zero);
	}

	void HandleMovement()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		rigidbody2D.velocity = new Vector2 (moveHorizontal * speed, moveVertical * speed);
	}

	void HandleRotation()
	{
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		difference.Normalize();
		
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0, 0, rotZ-90);
	}

	void HandleScreenBoundary ()
	{
		Camera mainCamera = Camera.main;
		Vector3 cameraPosition = mainCamera.transform.position;
		Vector3 currentPosition = transform.position;
		Vector3 newPosition = transform.position; 
		
		float xMax = cameraPosition.x + Constant.SCREEN_WIDTH_HALF - renderer.bounds.size.x / 2;
		float xMin = cameraPosition.x - Constant.SCREEN_WIDTH_HALF + renderer.bounds.size.x / 2;
		float yMax = cameraPosition.y + Constant.SCREEN_HEIGHT_HALF - renderer.bounds.size.y / 2;
		float yMin = cameraPosition.y - Constant.SCREEN_HEIGHT_HALF + renderer.bounds.size.y / 2;
		
		// Detects if the user is out of bounds for each coordinate.
		// If so, it moves the user to the nearest boundary.
		if (currentPosition.x < xMin || currentPosition.x > xMax) {
			newPosition.x = Mathf.Clamp(currentPosition.x, xMin, xMax );
		} // if (currentPosition.x < xMin || currentPosition.x > xMax)
		if (currentPosition.y < yMin || currentPosition.y > yMax) {
			newPosition.y = Mathf.Clamp( currentPosition.y, yMin, yMax );
		} // if (currentPosition.y < yMin || currentPosition.y > yMax)
		
		transform.position = newPosition;
	} // void HandleScreenBoundary ()

	void HurtAnimationEnd () {
		Animator anim = GetComponent<Animator> ();
		anim.SetBool ("IsAttacked", false);
	}

	void IsAttacked() {
		//Lets place some game ending code here, in case lives = 0 ...
        lives--;
		
		Animator anim = GetComponent<Animator> ();
		 anim.SetBool ("IsAttacked", true);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.tag == "Enemy" && other.GetComponent<Enemy>().health > 0) {
			IsAttacked ();
			wood += 5;
		} 
    }

    void HandleInput()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (CurrentMode == GameMode.COMBAT)
            {
                CurrentMode = GameMode.CONSTRUCT;
                // Debug.Log("CONSTRUCT MODE ENABLED");
            }
            else
            {
                CurrentMode = GameMode.COMBAT;
                if (constructPanel.activeSelf) constructPanel.SetActive(false);

                // Debug.Log("COMBAT MODE ENABLED");
            }
        }
    }


	public GameMode CurrentMode
	{
		get { return gameMode; }
		set { gameMode = value; }
	}

    public int Lives { 
        get { return lives; }
        set { lives = value; }
    } 
    public int Ammo { 
        get { return ammo; }
        set { ammo = value; }
    }
    public int Metal { 
        get { return metal; }
        set { metal = value; }
    }
    public int Wood { 
        get { return wood; }
        set { wood = value; }
    }
    public int Copper {
        get { return copper; }
        set { copper = value; }
    }

	public void giveItem(ItemController.ItemType type, int amount) {
		switch (type) {
			case ItemController.ItemType.AMMO:
				ammo += amount;
				break;
			case ItemController.ItemType.COPPER:
				copper += amount;
				break;
			case ItemController.ItemType.METAL:
				metal += amount;
				break;
			case ItemController.ItemType.WOOD:
				wood += amount;
				break;
			default:
				break;
		}
	}

	public void playOneShot(AudioClip clip)
	{
		audio.PlayOneShot (clip);
	}

}
