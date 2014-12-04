using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    private GameObject cam;
    private GameObject player;
    private PlayerController playerController;
    private Animator anim;

    void Awake() {
        cam = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
       Debug.Log(playerController.lives);
        if (playerController.lives <= 0)
        {
            playGameOver();
        }

    }

    void playGameOver()
    {
        anim.SetBool("isGameOver", true);
        cam.GetComponent<AudioSource>().Pause();

    }

    public void returnToMenu()
    {
        Application.LoadLevel("Main Menu");
    }


}
