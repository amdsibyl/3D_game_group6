using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomePageManager : MonoBehaviour {


	public GameObject homeWindow;
	public static bool diffFlag = false;
	public static bool backHome = false;
	public static bool HomeWindowOpen = false;
	//public static bool starUpdate = false;

	public AudioSource clickSound;
	public AudioSource ballSound;

	public Rigidbody ballRigidbody;
	public Button ball;
	public Button play;
	public Button tutor;
	public Image black;
	Color c;
	float startTime = -1;
	int ctr = 0;

	void Start () {
		diffFlag = false;
		backHome = false;
		HomeWindowOpen = false;

		startTime = -1;
		ctr = 0;

		ball.onClick.AddListener (BallOnClick);
		play.onClick.AddListener (PlayOnClick);
		tutor.onClick.AddListener (TutorOnClick);

		c = black.color;
		c.a = 1;
	}

	void Update () {
		
		//print ("home:" + HomeWindowOpen);
		if (c.a >= 0.0f) {
			c.a -= 0.01f;
			black.color = c;
		} else {
			black.enabled = false;
		}
		if (startTime != -1) {
			if (Time.time - startTime <= 3.0f)
				ctr++;
			else
				ctr = 0;
		}
		if (backHome == true) {
			homeWindow.SetActive (true);
			HomeWindowOpen = true;
			backHome = false;
		}

	}
	void BallOnClick(){
		ballSound.Play ();
		if (startTime == -1) {
			startTime = Time.time;
		} else if (ctr >= 5) {
			
		}
	}

	void PlayOnClick(){
		clickSound.Play ();
		diffFlag = true;
		homeWindow.SetActive (false);
		HomeWindowOpen = false;
		//starUpdate = true;
		//print ("home1:" + HomeWindowOpen);
	}

	void TutorOnClick(){
		clickSound.Play ();
		HomeWindowOpen = false;
		//print ("home2:" + HomeWindowOpen);

	}
}
