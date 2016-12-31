using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	Rigidbody player;
	public static int NowLevel = 3;
	public GameObject[] Level;
	public Vector3[] startCoordinate;
	/* LEVEL1:(3,5,2)
	 * LEVEL2:(5,5,2)
	 * LEVEL3:(1,5,0) */


	public Button restart;
	public Button next;
	public Button home;
	public GameObject lvWindow;

	public Image perfect;
	public Image excellent;
	public Image great;
	public Image good;

	public Image[] stars = new Image[3];
	public Image[] yStars = new Image[3];


	/*
	// UI
	public int UIwindowWidth = 200;
	public int UIwindowHight = 100;
	Rect UIwindowRect;
	*/

	public static bool LvupWindowOpen = false;
	int windowSwitch = 0;


	void Start () {
		player = GetComponent<Rigidbody> ();
		SetLevel ();
		lvWindow.SetActive (false);
		Disabled ();

		restart.onClick.AddListener (RestartOnClick);
		next.onClick.AddListener (NextOnClick);
		home.onClick.AddListener (HomeOnClick);
	}
	
	void Update () {
		
		if (PlayerMovement.LevelUpFlag == true) {

			TextManager.text.text = "-";
			lvWindow.SetActive(true);
			LvupWindowOpen = true;
			foreach (Image img in stars) {
				img.enabled = true;
			}

			if ((float)ScoreManager.step / ScoreManager.maxStep >= 0.5f) {
				perfect.enabled = true;
				foreach (Image img in yStars) {
					img.enabled = true;
				}
			} else if ((float)ScoreManager.step / ScoreManager.maxStep >= 0.3f) {
				excellent.enabled = true;
				yStars [0].enabled = true;
				yStars [1].enabled = true;

			} else if ((float)ScoreManager.step / ScoreManager.maxStep >= 0.2f) {
				great.enabled = true;
				yStars [0].enabled = true;
			} else {
				good.enabled = true;
			}

			//if nowLevel=3???


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
		ScoreManager.maxStep = (int)Mathf.Pow ((NowLevel + 3), 2) - NowLevel * 4; 
		player.transform.position = Vector3.MoveTowards(player.transform.position, startCoordinate[NowLevel-1] , 6f);

	}

	void RestartOnClick(){
		//Debug.Log ("RestartOnClick");
		//Resetter.ResetFlag = true;
		SceneManager.LoadScene("Proj01");
		ScoreManager.stepUpdate = true;
		Time.timeScale = 1;
		Disabled ();
		LvupWindowOpen = false;
	}

	void NextOnClick(){
		//Debug.Log ("NextOnClick");
		++NowLevel;
		SetLevel ();
		//Resetter.ResetFlag = true;
		SceneManager.LoadScene("Proj01");
		ScoreManager.maxStep = (int)Mathf.Pow ((NowLevel + 3), 2) - NowLevel * 4;
		ScoreManager.stepUpdate = true;
		Time.timeScale = 1;
		Disabled ();
		LvupWindowOpen = false;
	}

	void HomeOnClick(){
		//Debug.Log ("HomeOnClick");
		//home
		//Application.Quit ();

		Time.timeScale = 1;
		Disabled ();
		//LvupWindowOpen = false;
	}

	void Disabled(){
		
		perfect.enabled = false;
		excellent.enabled = false;
		great.enabled = false;
		good.enabled = false;

		foreach (Image img in yStars) {
			img.enabled = false;
		}
		foreach (Image img in stars) {
			img.enabled = false;
		}
	}

	/*
	void LvupWindow (int windowID)
	{
		GUI.Label (new Rect (5, 15, 200, 30), "Level completed!");
		LvupWindowOpen = true;

		if (GUI.Button (new Rect (15, 50, 75, 20), "Quit")) {
			Application.Quit ();	//only work when build out to the game
			Time.timeScale = 1;
			LvupWindowOpen = false;
		} 
		if (GUI.Button (new Rect (110, 35, 75, 20), "Restart")) {
			windowSwitch = 0;
			ScoreManager.step = 0;
			LvupWindowOpen = false;
			SceneManager.LoadScene("Proj01");
			Time.timeScale = 1;
		} 
		if (GUI.Button (new Rect (110, 75, 75, 20), "Continue")) {
			windowSwitch = 0;
			SetLevel ();
			SceneManager.LoadScene("Proj01");
			ScoreManager.step = 0;
			Time.timeScale = 1;
			LvupWindowOpen = false;
		} 

	}
	*/


}
