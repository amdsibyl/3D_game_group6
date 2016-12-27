﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour {

	// Quit
	public int QuitwindowWidth = 200;
	public int QuitwindowHight = 100;
	public static bool QuitWindowOpen = false;
	Rect QuitwindowRect;

	// UI
	public int UIwindowWidth = 80;
	public int UIwindowHight = 25;
	bool back = false;
	//bool UIWindowOpen = false;
	Rect UIwindowRect;

	int windowSwitch = 0;
	float alpha = 0;

	void GUIAlphaColor_0_To_1 ()
	{
		if (alpha < 1) {
			alpha += Time.deltaTime;
			GUI.color = new Color (1, 1, 1, alpha);
		} 
	}

	// Init
	void Awake ()
	{
		UIwindowRect = new Rect ( 0, 0, UIwindowWidth, UIwindowHight);
		QuitwindowRect = new Rect ( (Screen.width - QuitwindowWidth) / 2, (Screen.height - QuitwindowHight) / 2, QuitwindowWidth, QuitwindowHight);
	}

	void Update ()
	{
		//if (Input.GetKeyDown ("escape") || back == true) {
		if (Input.GetKeyDown ("escape")) {
			Time.timeScale = 0;
			windowSwitch = 1;
			alpha = 0; // Init Window Alpha Color
			back = false;
		}
			
	}

	void OnGUI ()
	{ 
		GUIAlphaColor_0_To_1 ();
		if (GUI.Button (new Rect (0, 0, 80, 25), "← Back")){
			back = true;
		}

		if (windowSwitch == 1) {
			GUI.backgroundColor = Color.black;
			QuitwindowRect = GUI.Window (0, QuitwindowRect, QuitWindow, "");
		}

	}

	void QuitWindow (int windowID)
	{
		GUI.Label (new Rect (5, 15, 200, 30), "Are you sure to quit?");

		QuitWindowOpen = true;
		if (GUI.Button (new Rect (15, 50, 75, 20), "Quit")) {
			Application.Quit ();	//only work when build out to the game
			Time.timeScale = 1;
			QuitWindowOpen = false;
		} 
		if (GUI.Button (new Rect (110, 30, 75, 20), "Restart")) {
			SceneManager.LoadScene("Proj01");
			Time.timeScale = 1;
			QuitWindowOpen = false;
		} 
		if (GUI.Button (new Rect (110, 70, 75, 20), "Cancel")) {
			windowSwitch = 0; 
			Time.timeScale = 1;
			QuitWindowOpen = false;
		} 

		GUI.DragWindow (); 

	}

		
}