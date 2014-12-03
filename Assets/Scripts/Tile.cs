using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    GameObject constructUI;

    void Awake()
    {
        constructUI = GameObject.Find("ConstructPanel");
    }

    public void CreateTurret(Object turret)
    {
        Instantiate(turret, new Vector3(this.transform.position.x, this.transform.position.y, -1), Quaternion.identity);
    }

    void OnMouseDown()
    {
        GameObject player = GameObject.Find("Player");

        
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
