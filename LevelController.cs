using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

	public Button button2;
	public Button button3;
	public Button button4;
	public Button button5;
	public Button button6;
	public Button button7;
	public Button button8;
	public Button button9;
	public Button button10;

	public static bool button2Enable = false;
	public static bool button3Enable = false;
	public static bool button4Enable = false;
	public static bool button5Enable = false;
	public static bool button6Enable = false;
	public static bool button7Enable = false;
	public static bool button8Enable = false;
	public static bool button9Enable = false;
	public static bool button10Enable = false;

	// Use this for initialization
	void Awake () {
		button2.interactable = false;
		button3.interactable = false;
		button4.interactable = false;
		button5.interactable = false;
		button6.interactable = false;
		button7.interactable = false;
		button8.interactable = false;
		button9.interactable = false;
		button10.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (button2Enable == true)
			button2.interactable = true;
		if (button3Enable == true)
			button3.interactable = true;
		if (button4Enable == true)
			button4.interactable = true;
		if (button5Enable == true)
			button5.interactable = true;
		if (button6Enable == true)
			button6.interactable = true;
		if (button7Enable == true)
			button7.interactable = true;
		if (button8Enable == true)
			button8.interactable = true;
		if (button9Enable == true)
			button9.interactable = true;
		if (button10Enable == true)
			button10.interactable = true;
		
	}
}
