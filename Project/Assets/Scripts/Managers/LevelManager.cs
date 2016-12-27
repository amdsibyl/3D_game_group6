using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelManager : MonoBehaviour {

	Rigidbody player;
	public static int NowLevel = 1;
	public GameObject[] Level;
	public Vector3[] startCoordinate;
	/* LEVEL1:(3,5,2)
	 * LEVEL2:(5,5,2)
	 * LEVEL3:(1,5,0) */

	// UI
	public int UIwindowWidth = 200;
	public int UIwindowHight = 100;
	Rect UIwindowRect;
	public static bool LvupWindowOpen = false;
	int windowSwitch = 0;


	void Start () {
		player = GetComponent<Rigidbody> ();
		SetLevel ();
	}
	
	void Update () {
		
		if (PlayerMovement.LevelUpFlag == true) {
			if (NowLevel < 3) {
				++NowLevel;
				//print (NowLevel);
				TextManager.text.text = "Press!";
				windowSwitch = 1;

			} else {
				//Finish
				print("Finish!");

			}

			PlayerMovement.LevelUpFlag = false;
		}

	}

	void SetLevel(){

		for (int i = 0; i < Level.Length; i++) {
			if (i + 1 == NowLevel) {
				Level [i].SetActive (true);
			}
			else {
				Level [i].SetActive (false);
			}
		}
		player.transform.position = Vector3.MoveTowards(player.transform.position, startCoordinate[NowLevel-1] , 6f);
		//SceneManager.LoadScene("Proj01");

	}


	void Awake ()
	{
		UIwindowRect = new Rect ( (Screen.width - UIwindowWidth) / 2, (Screen.height - UIwindowHight) / 2, UIwindowWidth, UIwindowHight);
	}


	void OnGUI ()
	{ 

		if (windowSwitch == 1) {
			GUI.backgroundColor = Color.black;
			UIwindowRect = GUI.Window (0, UIwindowRect, LvupWindow, "");
		} 
		/*
		else {
			GUIAlphaColor_0_To_1 ();
		}
		*/

	}

	void LvupWindow (int windowID)
	{
		GUI.Label (new Rect (5, 15, 200, 30), "Congratulations! Level completed!");

		LvupWindowOpen = true;
		if (GUI.Button (new Rect (15, 50, 75, 20), "Quit")) {
			Application.Quit ();	//only work when build out to the game
			Time.timeScale = 1;
			LvupWindowOpen = false;
		} 
		if (GUI.Button (new Rect (110, 50, 75, 20), "Continue")) {
			windowSwitch = 0;
			SetLevel ();
			SceneManager.LoadScene("Proj01");
			Time.timeScale = 1;
			LvupWindowOpen = false;
		} 

		GUI.DragWindow (); 

	}


}
