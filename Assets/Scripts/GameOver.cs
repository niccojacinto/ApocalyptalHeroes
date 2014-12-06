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
			
	}

    public void returnToMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    //IEnumerator MyDelay(int delay)
    //{
    //    yield return new WaitForSeconds(delay);
   // }
}
