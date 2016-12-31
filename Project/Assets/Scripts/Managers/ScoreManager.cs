using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static Text text;
	public static int maxStep = (int)Mathf.Pow (4, 2) - 4;
	public static int step;
	public static bool stepUpdate = false;

	public static int[] lvSteps = new int[3];
	public static bool[] lvStepsUpdate = new bool[3];
	string[] lv = new string[3];


	void Start(){
		/*
		foreach (int i in lvSteps) 
			i = (int)Mathf.Pow (i + 3, 2) - 4 * i;
		*/
		for (int i = 0; i < 3; i++) 
			lvStepsUpdate [i] = false;
		
		for (int i = 0; i < 3; i++) 
			lv [i] = "Lv" +(i + 1) + "Steps";


		if (PlayerPrefs.HasKey (lv[0])) {
			lvSteps[0] = PlayerPrefs.GetInt (lv[0]);
		} else {
			lvSteps[0] = PlayerPrefs.GetInt(lv[0], 0);
		}

		if (PlayerPrefs.HasKey (lv[1])) {
			lvSteps[1] = PlayerPrefs.GetInt(lv[1]);
		} else {
			lvSteps[1] = PlayerPrefs.GetInt(lv[1], 0);
		}

		if (PlayerPrefs.HasKey (lv[2])) {
			lvSteps[2] = PlayerPrefs.GetInt(lv[2]);
		} else {
			lvSteps[2] = PlayerPrefs.GetInt(lv[2], 0);
		}

		for (int i = 0; i < 3; i++) 
			print (lvSteps [i]);
		
	}
	void Awake ()
	{
		stepUpdate = false;
		step = maxStep;
		text = GetComponent <Text> ();

	}

	void Update () {

		for (int i = 0; i < 3; i++) {
			if (lvStepsUpdate [i] == true) {
				if (step > lvSteps [i]) {
					PlayerPrefs.SetInt (lv [i], step);
					PlayerPrefs.Save ();
				}
				print(PlayerPrefs.GetInt(lv[i]));
				lvStepsUpdate [i] = false;
				break;
			}
		}

		if (stepUpdate == true) {
			step = maxStep;
		}
		text.text = "" + step;

	}
}
