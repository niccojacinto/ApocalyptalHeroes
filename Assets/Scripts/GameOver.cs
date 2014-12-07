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
			400,
			1000,
			2000,
			3200,
			4500,
			6400,
			9000,
			11750
		};

		string[] minimumRank= new string[]
		{ 	
			"Broom Bristle",
			"Broom Shaft",
			"Broom",
			"Maid Cosplayer",
			"Stray Maid",
			"Janitor",
			"Maid",
			"Sweep King",
			"Sweep God"
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
