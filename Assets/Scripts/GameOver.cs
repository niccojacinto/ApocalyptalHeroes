using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    private GameObject cam;
    private GameObject player;
    private PlayerController playerController;
    private Animator anim;
    private AudioSource[] audios;

    void Awake()
    {
        cam = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        audios = GetComponents<AudioSource>();
        playerController = player.GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
 

    }

    public void GameOverSequence()
    {
        // Debug.Log(playerController.lives);

        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject tile in tiles)
        {
            Destroy(tile);
        }

        Destroy(GameObject.Find("MagicalZombieFactory"));
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

		HandleScore ();
        Destroy(player);
        playGameOver();

        
    }

    void playGameOver()
    {
        anim.SetBool("isGameOver", true);
        cam.GetComponent<AudioSource>().Pause();
        Debug.Log(audios[0]);
        audios[2].Play();
        //StartCoroutine(MyDelay(5));
        audios[1].Play();
        //StartCoroutine(MyDelay(2));
        audios[0].Play();



    }

	void HandleScore()
	{
		bool newRecord = false;

		float userScore = (Time.time 
			- GameObject.Find ("Main Camera").GetComponent<Game>().timeStart) * 10;

		float highScore;


		if (PlayerPrefs.HasKey ("Highscore")) {
			highScore = PlayerPrefs.GetFloat("Highscore");
			if (userScore > highScore) {
				highScore = userScore;
				PlayerPrefs.SetFloat("Highscore", userScore);
				newRecord = true;
			}
		} else {
			highScore = userScore;
			PlayerPrefs.SetFloat("Highscore", userScore);
			newRecord = true;
		}

		GameObject.Find ("Score").GetComponent<Text> ().text = "Score: " + (int)userScore;
		GameObject.Find ("Highscore").GetComponent<Text> ().text = "Highscore: " + (int)highScore
			+ (newRecord ? " (NEW)" : "");

		GameObject.Find ("Rank").GetComponent<Text> ().text = "Rank: " + GetRank ((int)userScore);
			
	}

    public void returnToMenu()
    {
        Application.LoadLevel("Main Menu");
    }

	public string GetRank(int score)
	{
		int[] minimumScore = new int[]
		{ 	
			0,
			300,
			600,
			1200,
			1500,
			1800,
			2100,
			2400,
            2700,
            3000,
            3300,
            3600,
            3900,
            4200,
            4500,
            4800,
            5100,
            5400,
            5700,
            6000,
            6300,
            6600,
            6900,
            7200,
            7500,
            7800,
            8100,
            8400,
            8700,
            9000,
            9300,
            9600,
            9900,
            10200,
            10500,
            10800,
            11100,
            11400,
            11700,
            12000
			
		};

		string[] minimumRank= new string[]
		{ 	
            "PVT Private",
            "PV2 Private 2",
            "PFC Private First Class",
            "SPC Specialist",
            "CPL Corporal",
            "SGT Sergeant",
            "SSG Staff Sergeant",
            "SFC Sergeant First Class",
            "MSG Master Sergeant",
            "1SG First Sergeant",
            "SGM Sergeant Major",
            "CSM Command Sergeant Major",
            "SMA Sergeant Major of the Army",
            "WO1 Warrant Officer",
            "CW2 Chief Warrant Officer 2",
            "CW3 Chief Warrant Officer 3",
            "CW4 Chief Warrant Officer 4",
            "CW5 Chief Warrant Officer 5",
            "2LT Second Lieutenant",
            "1LT First Lieutentant",
            "CPT Captain",
            "MAJ Major",
            "LTC Lieutenant Colonel",
            "Col Colonel",
            "BG Brigadier General (*)",
            "MG Major General (**)",
            "LTG Lieutentant General (***)",
            "GEN General (****)",
            "GA Army General (*****)",
            "SC Supreme Commander",
            "K the invoker (no specific order)",
			"Arcangel Nicco (no specific order)",
			"Cat Incarnate (no specific order)",
			"Proficient Libby (no specific order)",
			"Intrepid Jeff (no specific order)",
			"Wanderlust Fred (no specific order)",
			"Wondrous Tabby (no specific order)",
			"Mystical Bernie (no specific order)",
			"Ethereal Hamoun (no specific order)",
			"Godlike Umer (no specific order)"
		};

		for (int i = minimumScore.Length - 1; i > 0; i--) {
			if (minimumScore[i] < score) {return minimumRank[i]; }
		}
		return minimumRank[0];
	} // public string GetRank(int score)

    //IEnumerator MyDelay(int delay)
    //{
    //    yield return new WaitForSeconds(delay);
   // }
}
