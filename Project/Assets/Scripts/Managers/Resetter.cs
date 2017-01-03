﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Resetter : MonoBehaviour {
    public Rigidbody rigidbody;
    public float resetSpeed = 0.025f;

	public AudioSource loseAudio;
	public AudioSource clickSound;

	public Button restart;
	public Button home;
	public GameObject gameOverWindow;
	public GameObject pauseButton;
	public static bool ResetWindowOpen = false;
	public static bool ResetFlag = false;
	bool isPlaying = false;


	void Start () {
		ResetFlag = false;
		isPlaying = false;
		restart.onClick.AddListener (RestartOnClick);
		home.onClick.AddListener (HomeOnClick);
		gameOverWindow.SetActive (false);
    }
	
	void Update () {
		
		if (ScoreManager.step <= 0) {
			//game over
			if (isPlaying == false) {
				loseAudio.Play ();
				gameOverWindow.SetActive (true);
				pauseButton.SetActive (false);
				ResetWindowOpen = true;
				isPlaying = true;
			}
		}

	}

    void OnTriggerExit(Collider other) {
		if (other.GetComponent<Rigidbody> () == rigidbody) {
			gameOverWindow.SetActive (true);
			ResetWindowOpen = true;
			pauseButton.SetActive (false);
		}

    }

	void RestartOnClick(){
		clickSound.Play ();
		//Debug.Log ("RestartOnClick!");
		pauseButton.SetActive (true);
		ResetFlag = true;
		SceneManager.LoadScene("Proj01");
		ScoreManager.stepUpdate = true;
		Time.timeScale = 1;
		ResetWindowOpen = false;
	}

	void HomeOnClick(){
		clickSound.Play ();
		HomePageManager.backHome = true;
		Time.timeScale = 1;
		ScoreManager.step = 1;
		isPlaying = false;
		ResetWindowOpen = false;
	}


}
