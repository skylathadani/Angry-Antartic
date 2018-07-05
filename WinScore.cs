using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScore : MonoBehaviour {

	public Text scoreText;

	void Start () {
		scoreText.text = "Score: " + SetScore.score;
	}
}
