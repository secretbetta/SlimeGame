using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

///<summary>Menu screen functions</summary>
public class Menu : MonoBehaviour {

	///<summary>Loads into the first level</summary>
	public void StartGame() {
		SceneManager.LoadScene("Level0");
	}

	///<summary>Closes the game</summary>
	public void ExitGame()
    {
        Application.Quit();
    }
}
