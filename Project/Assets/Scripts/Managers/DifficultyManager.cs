using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour {

	public AudioSource clickSound;
	public GameObject player;
	public GameObject gameWindow;
	public GameObject difficultyWindow;
	public GameObject homeWindow;
	public GameObject[] lvWindow;

	public Image[] yStar1 = new Image[3];
	public Image[] yStar2 = new Image[3];
	public Image[] yStar3 = new Image[3];

	public GameObject[] star = new GameObject[3];
	/*
	public GameObject[] y1 = new GameObject[3];
	public GameObject[] y2 = new GameObject[3];
	public GameObject[] y3 = new GameObject[3];
*/

	public Button easy;
	public Button normal;
	public Button hard;
	public Button cancel;

	public static bool setLevelFlag = false;
	public static bool DiffWindowOpen = false;
	bool updated = false;

	void Start () {
		updated = false;
		//print (Resetter.ResetFlag);
		if (Resetter.ResetFlag == false) {
			player.SetActive (false);
			gameWindow.SetActive (false);
			difficultyWindow.SetActive (true);
			DiffWindowOpen = true;
			Disabled ();

			StarUpdate ();

		} else {
			setLevelFlag = true;
			player.SetActive (true);
			gameWindow.SetActive (true);
			homeWindow.SetActive (false);
			difficultyWindow.SetActive (false);
			DiffWindowOpen = false;
			Resetter.ResetFlag = false;
		}

		easy.onClick.AddListener (EasyOnClick);
		normal.onClick.AddListener (NormalOnClick);
		hard.onClick.AddListener (HardOnClick);
		cancel.onClick.AddListener (CancelOnClick);

	}
	
	void Update () {

		//print (HomePageManager.diffFlag);
		if (HomePageManager.diffFlag == true) {

			difficultyWindow.SetActive (true);
			DiffWindowOpen = true;

			if (updated == false) {
				Disabled ();
				StarUpdate ();
				updated = true;
			}

			player.SetActive (false);
			gameWindow.SetActive (false);

			lvWindow[0].SetActive (false);
			lvWindow[1].SetActive (false);
			lvWindow[2].SetActive (false);

		}

	}

	void EasyOnClick(){
		clickSound.Play ();
		LevelManager.NowLevel = 1;
		setLevelFlag = true;
		Resetter.ResetFlag = true;
		HomePageManager.diffFlag = false;
		HomePageManager.HomeWindowOpen = false;
		DiffWindowOpen = false;
		SceneManager.LoadScene("Proj01");
	}

	void NormalOnClick(){
		clickSound.Play ();
		LevelManager.NowLevel = 2;
		setLevelFlag = true;
		Resetter.ResetFlag = true;
		HomePageManager.diffFlag = false;
		HomePageManager.HomeWindowOpen = false;
		DiffWindowOpen = false;
		SceneManager.LoadScene("Proj01");
	}

	void HardOnClick(){
		clickSound.Play ();
		LevelManager.NowLevel = 3;
		setLevelFlag = true;
		Resetter.ResetFlag = true;
		HomePageManager.diffFlag = false;
		HomePageManager.HomeWindowOpen = false;
		DiffWindowOpen = false;
		SceneManager.LoadScene("Proj01");
	}

	void CancelOnClick(){
		clickSound.Play ();
		HomePageManager.backHome = true;
		//SceneManager.LoadScene ("Proj01");
	}

	void Disabled(){

		foreach (Image img in yStar1) {
			img.enabled = false;
		}
		foreach (Image img in yStar2) {
			img.enabled = false;
		}
		foreach (Image img in yStar3) {
			img.enabled = false;
		}
	}
	void StarUpdate(){

		for (int i = 0; i < 3; i++) {
			int now = PlayerPrefs.GetInt (HighScoreManager.lvStar [i]);
			star [i].SetActive (true);
			//print ("i:"+i+"now:" + now);
			if (now == 3) {
				if (i == 0) {
					yStar1 [0].enabled = true;
					yStar1 [1].enabled = true;
					yStar1 [2].enabled = true;
				}
				if (i == 1) {
					yStar2 [0].enabled = true;
					yStar2 [1].enabled = true;
					yStar2 [2].enabled = true;
				}
				if (i == 2) {
					yStar3 [0].enabled = true;
					yStar3 [1].enabled = true;
					yStar3 [2].enabled = true;
				}
			
			} else if (now == 2) {
				if (i == 0) {
					yStar1 [0].enabled = true;
					yStar1 [1].enabled = true;
				}
				if (i == 1) {
					yStar2 [0].enabled = true;
					yStar2 [1].enabled = true;
				}
				if (i == 2) {
					yStar3 [0].enabled = true;
					yStar3 [1].enabled = true;
				}
			} else if (now == 1) {
				if(i==0) yStar1 [0].enabled = true;
				if(i==1) yStar2 [0].enabled = true;
				if(i==2) yStar3 [0].enabled = true;
			}
			else{
				//print ("qqqqqqq");
			}
		}


	}

}
