using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

	public Rigidbody2D rb;
	public float releaseTime = 0.15f;
	public Rigidbody2D hook;
	public float maxDragDistance = 5f;
	public static bool isPressed = false;

	public GameObject nextBall;

	public LineRenderer catapultLineBack;
	public LineRenderer catapultLineFront;

	private CircleCollider2D circle;

	public static bool cameraMove;
	public static bool cameraLock;

	public static Scene curScene;
	public static string level;

	void Awake () {
		circle = GetComponent<CircleCollider2D>();
		cameraMove = false;
		cameraLock = false;

		curScene = SceneManager.GetActiveScene ();
		level = curScene.name;
	}

	// Use this for initialization
	void Start () {
		LineRendererSetup ();
	}

	void LineRendererSetup () {
		catapultLineBack.sortingLayerName = "Foreground";
		catapultLineBack.sortingLayerName = "Foreground";

	}


	void Update ()
	{
		if (isPressed) {
			Vector2 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

			if (Vector3.Distance (mousePos, hook.position) > maxDragDistance)
				rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
			else
				rb.position = mousePos;
		}
		LineRendererUpdate ();
	}

	void OnMouseDown ()
	{
		isPressed = true;
		rb.isKinematic = true;

		cameraLock = true;
	}


	void OnMouseUp ()
	{
		isPressed = false;
		rb.isKinematic = false;

		cameraMove = true;

		StartCoroutine (Release ());
	}

	void LineRendererUpdate() {
		Vector3 holdPoint = transform.position;
		holdPoint.x -= circle.radius;
		catapultLineFront.SetPosition (1, holdPoint);
		catapultLineBack.SetPosition (1, holdPoint);
		catapultLineFront.SetPosition (0, catapultLineFront.transform.position);
		catapultLineBack.SetPosition (0, catapultLineBack.transform.position);
		catapultLineBack.sortingOrder = 3;
		catapultLineBack.sortingOrder = 1; 
	}

	IEnumerator Release()
	{
		
		yield return new WaitForSeconds (releaseTime);
		catapultLineFront.SetPosition (0, catapultLineBack.transform.position);
		catapultLineBack.SetPosition (0, catapultLineFront.transform.position);

		//turn ball into a projectile
		GetComponent<SpringJoint2D> ().enabled = false;
		//can't mess with ball after it is released
		this.enabled = false;
		cameraLock = false;

		yield return new WaitForSeconds (2.5f);
		Button2.ballNum++;
		Debug.Log (Button2.ballNum);
		cameraMove = false;


		if (nextBall != null && Enemy.EnemiesAlive > 0) {
			nextBall.SetActive (true);	
		} else if (nextBall == null && Enemy.EnemiesAlive > 0){
			//basically if you loose (add a u loose screen here)
			StartCoroutine("Lose");
		}

		if (Enemy.EnemiesAlive <= 0) {
			StartCoroutine("Wait");
		}


	}

	IEnumerator Wait()
	{

		loadNextLevel ();
		yield return new WaitForSeconds(2f);
		if (level == "Level 10")
			SceneManager.LoadScene ("You Win!");
		else
			SceneManager.LoadScene("Load Screen");
	}

	IEnumerator Lose ()
	{
		yield return new WaitForSeconds (1f);

		SceneManager.LoadScene ("Game Over");
		SetScore.score = SetScore.score - SetScore.scoreGainedAtCurLevel;
	}

	public static void loadNextLevel() {
		if (level == "Main Level")
			LevelController.button2Enable = true;
		else if (level == "Level 2")
			LevelController.button3Enable = true;
		else if (level == "Level 3")
			LevelController.button4Enable = true;
		else if (level == "Level 4")
			LevelController.button5Enable = true;
		else if (level == "Level 5")
			LevelController.button6Enable = true;
		else if (level == "Level 6")
			LevelController.button7Enable = true;
		else if (level == "Level 7")
			LevelController.button8Enable = true;
		else if (level == "Level 8")
			LevelController.button9Enable = true;
		else if (level == "Level 9")
			LevelController.button10Enable = true;
	}
}
