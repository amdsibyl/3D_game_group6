using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static Text text;
	//int score = 0;
	public static int step = 0;

	void Awake ()
	{
		text = GetComponent <Text> ();
	}

	void Update () {
		
		text.text = "" + step;
	}
}
