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

	public GameObject playObj;
	public GameObject tutorObj;
	public GameObject leaveObj;

	public Button play;
	public Button tutor;
	public Button leave;
	public Image black;
	Color c;
	float startTime = -1;
	int ctr = 0;

	void Start () {
		playObj.SetActive (false);
		tutorObj.SetActive (false);
		leaveObj.SetActive (false);

		diffFlag = false;
		backHome = false;
		HomeWindowOpen = false;

		startTime = -1;
		ctr = 0;

		ball.onClick.AddListener (BallOnClick);
		play.onClick.AddListener (PlayOnClick);
		tutor.onClick.AddListener (TutorOnClick);
		leave.onClick.AddListener (LeaveOnClick);

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
		if (ctr >= 2) {
			playObj.SetActive (true);
		}
		if (ctr >= 5) {
			tutorObj.SetActive (true);
		}
		if (ctr >= 10) {
			leaveObj.SetActive (true);
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
		} else {
			//print (ctr);
			if (Time.time - startTime <= 3.0f)
				ctr++;
			else {
				ctr = 0;
				startTime = Time.time;
			}
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
	void LeaveOnClick(){
		Application.Quit ();
	}
}
