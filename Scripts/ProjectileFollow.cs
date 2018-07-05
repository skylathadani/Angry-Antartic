using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFollow : MonoBehaviour {

	public Transform projectile1;
	public Transform projectile2;
	public Transform projectile3;
	public Transform projectile;
	public Transform farLeft;
	public Transform farRight;
	public Vector3 newPosition;
	public Vector3 originalPosition;
	public bool realignTo1;
	public bool realignTo2;
	public bool realignTo3;


	void Start() {
		newPosition = transform.position;
		newPosition.x = projectile1.position.x;
		transform.position = newPosition;
		originalPosition = newPosition;
		realignTo1 = false;
		realignTo2 = false;
		realignTo3 = false;
	}


	// Update is called once per frame
	void Update () {
		if (Button2.ballNum == 1 && !realignTo1) {
			projectile = projectile1;
			newPosition.x = projectile1.position.x;
			realignTo1 = true;
		} else if (Button2.ballNum == 2 && !realignTo2) {
			projectile = projectile2;
			newPosition.x = projectile2.position.x;
			realignTo2 = true;
		} else if (Button2.ballNum == 3 && !realignTo3) {
			projectile = projectile3;
			newPosition.x = projectile3.position.x;
			realignTo3 = true;
		}
			
		if (Ball.cameraMove) {
			newPosition.x = projectile.position.x;
			newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);
		} else if (Ball.cameraLock) {
			newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farLeft.position.x);
		} else {
			Vector3 change = new Vector3 (1.0f, 0, 0);
			if (Input.GetKey ("left")) {
				newPosition = newPosition - change;
			} else if (Input.GetKey ("right")) {
				newPosition = newPosition + change;
			}
			newPosition.x = Mathf.Clamp (newPosition.x, farLeft.position.x, farRight.position.x);
		}
		transform.position = newPosition;


	}
}
