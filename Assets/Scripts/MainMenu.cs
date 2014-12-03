using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {


	public void newGame () {
        Application.LoadLevel("Level0"); 
	}
	
	public void exitGame () {
        Application.Quit();
	}
}
