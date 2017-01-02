using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static Text text;
	public static int maxStep = (int)Mathf.Pow (4, 2) - 4;
	public static int step;
	public static bool stepUpdate = false;


	void Awake ()
	{
		stepUpdate = false;
		maxStep = (int)Mathf.Pow (LevelManager.NowLevel + 3, 2) - 4 * LevelManager.NowLevel;
		step = maxStep;
		text = GetComponent <Text> ();

	}

	void Update () {

		if (stepUpdate == true) {
			maxStep = (int)Mathf.Pow (LevelManager.NowLevel + 3, 2) - 4 * LevelManager.NowLevel;
			step = maxStep;
		}
		text.text = "" + step;

	}
}
