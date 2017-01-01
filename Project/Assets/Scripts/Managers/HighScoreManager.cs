using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {
	public static Text text;
	public static int[] lvSteps = new int[3];
	public static bool[] lvStepsUpdate = new bool[3];
	string[] lv = new string[3];
	string highScore = "High Score: ";


	void Start () {
		//use with caution
		//PlayerPrefs.DeleteAll ();

		text = GetComponent <Text> ();

		for (int i = 0; i < 3; i++) 
			lvStepsUpdate [i] = false;

		for (int i = 0; i < 3; i++) 
			lv [i] = "Lv" +(i + 1) + "Steps";


		if (PlayerPrefs.HasKey (lv[0])) {
			lvSteps[0] = PlayerPrefs.GetInt (lv[0]);
			text.text = highScore + lvSteps[0];
		} else {
			lvSteps[0] = PlayerPrefs.GetInt(lv[0], 0);
			if(LevelManager.NowLevel==1)
				text.text = highScore + "0";
		}

		if (PlayerPrefs.HasKey (lv[1])) {
			lvSteps[1] = PlayerPrefs.GetInt(lv[1]);
			text.text = highScore + lvSteps[1];
		} else {
			lvSteps[1] = PlayerPrefs.GetInt(lv[1], 0);
			if(LevelManager.NowLevel==2)
				text.text = highScore + "0";
		}

		if (PlayerPrefs.HasKey (lv[2])) {
			lvSteps[2] = PlayerPrefs.GetInt(lv[2]);
			text.text = highScore + lvSteps[2];
		} else {
			lvSteps[2] = PlayerPrefs.GetInt(lv[2], 0);
			if(LevelManager.NowLevel==3)
				text.text = highScore + "0";
		}

		for (int i = 0; i < 3; i++) 
			print (lvSteps [i]);
	}

	void Update () {
		for (int i = 0; i < 3; i++) {
			if (lvStepsUpdate [i] == true) {
				if (ScoreManager.step > lvSteps [i]) {
					text.text = highScore + ScoreManager.step;
					PlayerPrefs.SetInt (lv [i], ScoreManager.step);
					PlayerPrefs.Save ();
				}
				print(PlayerPrefs.GetInt(lv[i]));
				lvStepsUpdate [i] = false;
				break;
			}
		}
	}
}
