using UnityEngine;
using System.Collections;

public class Construct : MonoBehaviour {

    DetectTiles detectTiles;
    PlayerController playerController;
    public Object turret;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        detectTiles = GetComponent<DetectTiles>();
    }
    public void CreateTurret()
    {
        if (playerController.Ammo >= 50
            && playerController.Metal >= 50
            && playerController.Wood >= 50
            && playerController.Copper >= 50
            )
        {
            playerController.Ammo -= 50;
            playerController.Metal -= 50;
            playerController.Wood -= 50;
            playerController.Copper -= 50;
            detectTiles.SelectedTile.GetComponent<Tile>().CreateTurret(turret);
        }
    }
}
