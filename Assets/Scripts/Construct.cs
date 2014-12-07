using UnityEngine;
using System.Collections;

public class Construct : MonoBehaviour {

    DetectTiles detectTiles;
    PlayerController playerController;
    public Object turret;
    public Object wall;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        detectTiles = GetComponent<DetectTiles>();
    }
    public void CreateTurret()
    {
        if (playerController.Metal >= 25
            && playerController.Wood >= 20
            && playerController.Copper >= 5
            && detectTiles.SelectedTile.GetComponent<Tile>().OccupiedBy == null)
        {
            playerController.Metal -= 25;
            playerController.Wood -= 20;
            playerController.Copper -= 5;
            detectTiles.SelectedTile.GetComponent<Tile>().CreateStructure(turret);
            detectTiles.SelectedTile.GetComponent<Tile>().OccupiedBy.GetComponent<Turret>().SndOnCreate();
        }
    }

    public void CreateWall()
    {
        if (playerController.Metal >= 15
            && playerController.Wood >= 15
            && playerController.Copper >= 15
            && detectTiles.SelectedTile.GetComponent<Tile>().OccupiedBy == null)
        {;
            playerController.Metal -= 15;
            playerController.Wood -= 15;
            playerController.Copper -= 15;
            detectTiles.SelectedTile.GetComponent<Tile>().CreateStructure(wall);
            detectTiles.SelectedTile.GetComponent<Tile>().OccupiedBy.GetComponent<Wall>().SndOnCreate();
        }
    }
}
