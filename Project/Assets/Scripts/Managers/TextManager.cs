using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManager : MonoBehaviour {

	public static int steps;
	Text text;

	void Awake ()
	{
		text = GetComponent <Text> ();
		steps = 0;
	}
		
	void Update ()
	{
		text.text = "" + steps;
	}
}
