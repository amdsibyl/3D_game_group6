using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour {

	Rigidbody player;
	public static int NowLevel = 1;
	public GameObject[] Level;
	public GameObject pauseButton;
	public Vector3[] startCoordinate;
	/* LEVEL1:(3,5,2)
	 * LEVEL2:(5,5,2)
	 * LEVEL3:(1,5,0) */

	public AudioSource winAudio;
	bool isPlaying = false;

	public Button restart;
	public Button next;
	public Button home;
	public Button endHome;
	public GameObject lvWindow;
	public GameObject gameComplete;

	public Image perfect;
	public Image excellent;
	public Image great;
	public Image good;

	public Image[] stars = new Image[3];
	public Image[] yStars = new Image[3];
	public static int nowStar;

	public static bool LvupWindowOpen = false;


	void Start () {
		player = GetComponent<Rigidbody> ();

		lvWindow.SetActive (false);
		Disabled ();
		isPlaying = false;

		restart.onClick.AddListener (RestartOnClick);
		next.onClick.AddListener (NextOnClick);
		home.onClick.AddListener (HomeOnClick);
		endHome.onClick.AddListener (HomeOnClick);
		nowStar = 0;
	}
	
	void Update () {
		
		if (DifficultyManager.setLevelFlag == true) {
			SetLevel ();
			DifficultyManager.setLevelFlag = false;
		}
		if (PlayerMovement.LevelUpFlag == true) {

			TextManager.text.text = "-";
			lvWindow.SetActive(true);
			if (isPlaying == false) {
				winAudio.Play ();
				isPlaying = true;
			}
			LvupWindowOpen = true;
			foreach (Image img in stars) {
				img.enabled = true;
			}

			if ((float)ScoreManager.step / ScoreManager.maxStep >= 0.5f) {
				perfect.enabled = true;
				foreach (Image img in yStars) {
					img.enabled = true;
				}
				nowStar = 3;

			} else if ((float)ScoreManager.step / ScoreManager.maxStep >= 0.3f) {
				excellent.enabled = true;
				yStars [0].enabled = true;
				yStars [1].enabled = true;
				nowStar = 2;

			} else if ((float)ScoreManager.step / ScoreManager.maxStep >= 0.2f) {
				great.enabled = true;
				yStars [0].enabled = true;
				nowStar = 1;
			} else {
				good.enabled = true;
				nowStar = 0;
			}
			//print ("nowStar:::"+nowStar);

			if (NowLevel == 3) {
				//what should we do?
			}

			isPlaying = false;
			PlayerMovement.LevelUpFlag = false;
			//////////////////
			pauseButton.SetActive (false);

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
		pauseButton.SetActive (true);
		Resetter.ResetFlag = true;
		ScoreManager.stepUpdate = true;
		Time.timeScale = 1;
		Disabled ();

		HighScoreManager.lvStepsUpdate [NowLevel - 1] = true;
		winAudio.Stop ();
		SceneManager.LoadScene("Proj01");
		LvupWindowOpen = false;
	}

	void NextOnClick(){
		//Debug.Log ("NextOnClick");
		pauseButton.SetActive (true);
		HighScoreManager.lvStepsUpdate [NowLevel - 1] = true;
		if (NowLevel < 3) {
			++NowLevel;
			SetLevel ();
			SceneManager.LoadScene("Proj01");
		} else {
			gameComplete.SetActive (true);
			//LvupWindowOpen = false;
		}
		Resetter.ResetFlag = true;
		ScoreManager.maxStep = (int)Mathf.Pow ((NowLevel + 3), 2) - NowLevel * 4;
		ScoreManager.stepUpdate = true;

		Time.timeScale = 1;
		Disabled ();
		winAudio.Stop ();
	}

	void HomeOnClick(){
		HomePageManager.backHome = true;
		HighScoreManager.lvStepsUpdate [NowLevel - 1] = true;
		Time.timeScale = 1;
		Disabled ();
		winAudio.Stop ();
		//SceneManager.LoadScene ("Proj01");
		LvupWindowOpen = false;
		gameComplete.SetActive (false);
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

}
