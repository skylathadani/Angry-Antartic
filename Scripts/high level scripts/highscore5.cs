using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class highscore5 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (SetScore.score < 11) {
			SceneManager.LoadScene("NotEnoughPoints");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
