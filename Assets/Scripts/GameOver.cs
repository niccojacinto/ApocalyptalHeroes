using UnityEngine;
using System.Collections;

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

    public void returnToMenu()
    {
        Application.LoadLevel("Main Menu");
    }

    //IEnumerator MyDelay(int delay)
    //{
    //    yield return new WaitForSeconds(delay);
   // }
}
