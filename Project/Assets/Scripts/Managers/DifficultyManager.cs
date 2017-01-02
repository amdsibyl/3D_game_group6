using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour {

	public GameObject player;
	public GameObject gameWindow;
	public GameObject difficultyWindow;

	public Image[] yStar1 = new Image[3];
	public Image[] yStar2 = new Image[3];
	public Image[] yStar3 = new Image[3];
	public GameObject[] star = new GameObject[3];

	public Button easy;
	public Button normal;
	public Button hard;
	public Button cancel;

	public static bool setLevelFlag = false;


	void Start () {
		
		//print (Resetter.ResetFlag);
		if (Resetter.ResetFlag == false) {
			player.SetActive (false);
			gameWindow.SetActive (false);
			difficultyWindow.SetActive (true);
			Disabled ();

			for (int i = 0; i < 3; i++) {
				int now = PlayerPrefs.GetInt (HighScoreManager.lvStar [i]);
				star [i].SetActive (true);
				//print ("now:" + now);
				switch (now) {
				case 3:
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
					break;
				case 2:
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
					break;
				case 1:
					if(i==0) yStar1 [0].enabled = true;
					if(i==1) yStar2 [0].enabled = true;
					if(i==2) yStar3 [0].enabled = true;
					break;

				}
			}

		} else {
			setLevelFlag = true;
			player.SetActive (true);
			gameWindow.SetActive (true);
			difficultyWindow.SetActive (false);
			Resetter.ResetFlag = false;
		}
		easy.onClick.AddListener (EasyOnClick);
		normal.onClick.AddListener (NormalOnClick);
		hard.onClick.AddListener (HardOnClick);
		cancel.onClick.AddListener (CancelOnClick);

	}
	
	void Update () {


	}

	void EasyOnClick(){
		LevelManager.NowLevel = 1;
		setLevelFlag = true;
		Resetter.ResetFlag = true;
		SceneManager.LoadScene("Proj01");
	}

	void NormalOnClick(){
		LevelManager.NowLevel = 2;
		setLevelFlag = true;
		Resetter.ResetFlag = true;
		SceneManager.LoadScene("Proj01");
	}

	void HardOnClick(){
		LevelManager.NowLevel = 3;
		setLevelFlag = true;
		Resetter.ResetFlag = true;
		SceneManager.LoadScene("Proj01");
	}

	void CancelOnClick(){



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
		/*
		foreach (Image img in star) {
			img.enabled = false;
		}*/
	}

}
