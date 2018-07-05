using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public GameObject deathEffect;

	public float health = 3f;

	public static int EnemiesAlive;

	public Text scoreText;


	void Start(){

		EnemiesAlive++;
		Debug.Log (EnemiesAlive);

		scoreText.text = "Score: " + SetScore.score;

	}
	//get information about the collision
	void OnCollisionEnter2D(Collision2D colInfo)
	{
		if (colInfo.relativeVelocity.magnitude > health) {
			Die ();
		}
	}

	void Die(){
		Instantiate (deathEffect, transform.position, Quaternion.identity);

		EnemiesAlive--; 

		SetScore.score++;
		SetScore.scoreGainedAtCurLevel++;

		scoreText.text = "Score: " + SetScore.score;

		if (EnemiesAlive <= 0) {
			//load next level here
			StartCoroutine("Wait");
		}

			
		Destroy (gameObject); 

	}

	IEnumerator Wait()
	{

		Ball.loadNextLevel ();
		yield return new WaitForSeconds(2);

		if (SceneManager.GetActiveScene().name == "Level 10")
			SceneManager.LoadScene ("You Win!");
		else
			SceneManager.LoadScene("Load Screen");
	}
}
//}
