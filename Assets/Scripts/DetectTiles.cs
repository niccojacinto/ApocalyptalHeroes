using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetectTiles : MonoBehaviour
{
    PlayerController playerController;
    //public float minDistance;
    private GameObject selectedTile;
    public float scanFrequency;

    GameObject[] allTiles;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        InvokeRepeating("ScanSurround", 0, scanFrequency);
        allTiles = GameObject.FindGameObjectsWithTag("Tile");
    }


    void ScanSurround()
    {
		int playerX =  (int)System.Math.Floor(playerController.transform.position.x + 0.5f);
		int playerY =  (int)System.Math.Floor(playerController.transform.position.y + 0.5f); 
        switch (playerController.CurrentMode)
        {
            case PlayerController.GameMode.CONSTRUCT:

                foreach (GameObject tileInstance in allTiles)
                {
					if (System.Math.Abs(playerX - tileInstance.transform.position.x) <= 1 &&
				    System.Math.Abs(playerY - tileInstance.transform.position.y) <= 1)
                    {
                        tileInstance.GetComponent<SpriteRenderer>().color = Color.gray;
                    }
                    else
                    {
                        tileInstance.GetComponent<SpriteRenderer>().color = Color.white;
                    }
                }
                break;
            case PlayerController.GameMode.COMBAT:
                foreach (GameObject tileInstance in allTiles)
                {
                    tileInstance.GetComponent<SpriteRenderer>().color = Color.white;
                }
                break;

            default: break;
        }
    }

    public GameObject SelectedTile
    {
        get { return selectedTile; }
        set { selectedTile = value; }
    }


}