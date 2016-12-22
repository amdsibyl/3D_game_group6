using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManager : MonoBehaviour {

	public static int mode;
	/* Mode 0: Decide the steps
	   Mode 1: Change direction */
	public static int data;
	/* Mode 0: Decide the steps
	   Mode 1: Change direction */
	public static int nowDirection = 0;
	Text text;

	void Awake ()
	{
		text = GetComponent <Text> ();
		mode = 0;
		data = 0;
	}
		
	void Update ()
	{
		if (EnergyManagerScript.UpdateFlag == true) {
			if (mode == 0) //number of steps
				text.text = "" + data;
			else {
				//change direction
				switch (data) {
				case 0:
					text.text = "↑";
					break;

				case 1:
					text.text = "→";
					break;

				case 2:
					text.text = "↓";
					break;

				case 3:
					text.text = "←";
					break;

				default:
					text.text = "Press!";
					break;
				}
				nowDirection = data;
			}
		}
		else if (EnergyManagerScript.Done == true) {
			//text.text = "Press!";
		}
	}
}
