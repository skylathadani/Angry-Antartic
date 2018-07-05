using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HighLevel4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (SetScore.score < 8) {
			SceneManager.LoadScene("NotEnoughPoints");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
