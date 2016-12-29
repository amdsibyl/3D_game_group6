using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Resetter : MonoBehaviour {
    public Rigidbody rigidbody;
    public float resetSpeed = 0.025f;

	public int UIwindowWidth = 200;
	public int UIwindowHight = 100;
	bool ResetWindowOpen = false;
	Rect UIwindowRect;
	int windowSwitch = 0;

	void Start () {
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
			windowSwitch = 1;
	}

    void OnTriggerExit(Collider other) {
		if (other.GetComponent<Rigidbody> () == rigidbody)
			windowSwitch = 1;

    }

	void Awake(){
		UIwindowRect = new Rect ( (Screen.width - UIwindowWidth) / 2, (Screen.height - UIwindowHight) / 2, UIwindowWidth, UIwindowHight);
	}

	void OnGUI ()
	{ 

		if (windowSwitch == 1) {
			GUI.backgroundColor = Color.black;
			UIwindowRect = GUI.Window (0, UIwindowRect, ResetWindow, "");
		} 

	}

	void ResetWindow (int windowID)
	{
		GUI.Label (new Rect (5, 15, 200, 30), "Oops... You Failed! Play Again?");
		ResetWindowOpen = true;

		if (GUI.Button (new Rect (15, 50, 75, 20), "Quit")) {
			Application.Quit ();	//only work when build out to the game
			ResetWindowOpen = false;
		} 
		if (GUI.Button (new Rect (110, 50, 75, 20), "Restart")) {
			windowSwitch = 0;
			ScoreManager.step = 0;
			SceneManager.LoadScene("Proj01");
			Time.timeScale = 1;
			ResetWindowOpen = false;
		} 

		GUI.DragWindow (); 

	}
}
