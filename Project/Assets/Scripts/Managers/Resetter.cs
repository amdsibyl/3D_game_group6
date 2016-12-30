using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Resetter : MonoBehaviour {
    public Rigidbody rigidbody;
    public float resetSpeed = 0.025f;

	public Button restart;
	public Button home;
	public GameObject gameOverWindow;
	public static bool ResetWindowOpen = false;


	void Start () {
		restart.onClick.AddListener (RestartOnClick);
		home.onClick.AddListener (HomeOnClick);
		gameOverWindow.SetActive (false);
    }
	
	void Update () {
		
		if (ScoreManager.step <= 0) {
			//game over
			gameOverWindow.SetActive (true);
		}

	}

    void OnTriggerExit(Collider other) {
		if (other.GetComponent<Rigidbody> () == rigidbody)
			gameOverWindow.SetActive (true);

    }

	void RestartOnClick(){
		//Debug.Log ("RestartOnClick!");
		SceneManager.LoadScene("Proj01");
		ScoreManager.stepUpdate = true;
		Time.timeScale = 1;
		ResetWindowOpen = false;
	}

	void HomeOnClick(){
		//Debug.Log ("HomeOnClick!");
		//home
		Time.timeScale = 1;
		gameOverWindow.SetActive (false);
		ResetWindowOpen = false;
	}




}
