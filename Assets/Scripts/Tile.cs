using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    static GameObject player;
    GameObject constructUI;
    private GameObject occupiedBy;

    void Awake()
    {
        constructUI = GameObject.Find("ConstructPanel");
        player = GameObject.Find("Player");
    }

    public void CreateStructure(Object structure)
    {
       occupiedBy = Instantiate(structure, new Vector3(this.transform.position.x, this.transform.position.y, -1), Quaternion.identity) as GameObject;
    }

    void OnMouseDown()
    {

        DetectTiles detectTiles = player.GetComponent<DetectTiles>();
        if (this.GetComponent<SpriteRenderer>().color == Color.gray)
        {
            //Show UI 
            constructUI.GetComponent<ConstructPanelBehaviour>().Show();
            //Select Tile by player
            this.GetComponent<SpriteRenderer>().color = Color.green;
            detectTiles.SelectedTile = this.gameObject;
        }
    }

}
