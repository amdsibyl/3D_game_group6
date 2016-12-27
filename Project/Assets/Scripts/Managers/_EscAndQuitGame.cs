using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//按esc可以選擇是否離開遊戲
//應該是因為在編輯者模式，所以按quit後沒辦法離開
//輸出成可執行檔之後應該就可以正常quit遊戲

public class EscAndQuitGame : MonoBehaviour
{
	// public
	public int windowWidth = 200;
	public int windowHight = 100;
	public static bool QuitWindowOpen = false;
	//public static bool Done = false;

	// private
	Rect windowRect;
	int windowSwitch = 0;
	float alpha = 0;


	// Init
	void Awake ()
	{
		windowRect = new Rect ( (Screen.width - windowWidth) / 2, (Screen.height - windowHight) / 2, windowWidth, windowHight);
	}

	void Update ()
	{
		/*
		if (Input.GetKeyDown ("escape") || UIManager.back == true) {
			Time.timeScale = 0;
			windowSwitch = 1;
			alpha = 0; // Init Window Alpha Color
			UIManager.back = false;
		}
		*/
	}

	void OnGUI ()
	{ 
		
		if (windowSwitch == 1) {
			//GUIAlphaColor_0_To_1 ();
			GUI.backgroundColor = Color.black;
			windowRect = GUI.Window (0, windowRect, QuitWindow, "Are you sure to quit?");
		}
	}

	void QuitWindow (int windowID)
	{
		//GUI.Label (new Rect (5, 15, 200, 30), "Are you sure to quit game ?");

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
		//Done = true;

	}

}