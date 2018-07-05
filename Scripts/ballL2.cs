using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ballL2 : MonoBehaviour {
	public Rigidbody2D rg;
	public float releaseTime = 0.15f;
	public Rigidbody2D hook;
	public float maxDragDistance = 5f;
	private bool isPressed = false;

	public GameObject nextBall;
	void Update ()
	{
		if (isPressed)
		{
			//Dragging ();
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
				rg.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
			else
				rg.position = mousePos;
		}

		Debug.Log (Enemy.EnemiesAlive);
	}
	void OnMouseDown()
	{
		isPressed = true;
		rg.isKinematic = true;
		StartCoroutine (Release ());
	}

	void OnMouseUp()
	{
		isPressed = false;
		rg.isKinematic = false; 
	}

	IEnumerator Release()
	{
		yield return new WaitForSeconds (releaseTime);

		//turn ball into a projectile
		GetComponent<SpringJoint2D> ().enabled = false;
		//can't mess with ball after it is released
		this.enabled = false;

		yield return new WaitForSeconds (2f);
		if (nextBall != null && Enemy.EnemiesAlive > 0) {
			nextBall.SetActive (true);	
		} else {
			//basically if you loose (add a u loose screen here)
			yield return new WaitForSeconds (3f);
			Enemy.EnemiesAlive = 0;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

		if (Enemy.EnemiesAlive <= 0) {
			yield return new WaitForSeconds (2f);
			SceneManager.LoadScene ("You Win!");
		}



	}
}
 
