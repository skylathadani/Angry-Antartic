using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Button))]
public class Button2 : MonoBehaviour {

	public static int ballNum = 1;


	public void changeScene(string scenename)
	{
		SceneManager.LoadScene (scenename);
		ballNum = 1;
		Enemy.EnemiesAlive = 0;
		SetScore.scoreGainedAtCurLevel = 0;
	}


	void EndGame(){
		Application.Quit();
	}

}
