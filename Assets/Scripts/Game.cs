using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public Object player;
	public GameState gameState;

	public enum GameState {RUNNING, PAUSED, GAMEOVER}

	void Start()
	{
		gameState = GameState.RUNNING;
		//Instantiate(player, new Vector3(0, 0, -1), Quaternion.identity);
	}
		           
	public GameState CurrentState
	{
			get { return gameState;}
			set { gameState = value;}
	}


}
