using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class lvl7 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (SetScore.score < 15) {
			SceneManager.LoadScene("NotEnoughPoints");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
