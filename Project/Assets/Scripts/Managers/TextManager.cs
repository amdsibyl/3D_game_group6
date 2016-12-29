using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManager : MonoBehaviour {

	public static Text text;
	float startTime;

	void Awake ()
	{
		text = GetComponent <Text> ();
	}
		
	void Update ()
	{ 
		if (EnergyManagerScript.UpdateFlag == true) {
			if (PlayerMovement.mode == 0) //number of steps
				text.text = "" + PlayerMovement.data;
			else if (PlayerMovement.mode == 1) {
				//change direction
				switch (PlayerMovement.data) {
				case 1:
					text.text = "↑";
					break;

				case 2:
					text.text = "→";
					break;

				case 3:
					text.text = "↓";
					break;

				case 0:
					text.text = "←";
					break;

				default:
					text.text = "Press!";
					break;
				}
			} else {
				//Red Mode
				text.text = "" + PlayerMovement.data;
			}
			startTime = Time.time;
		} 
		else if (PlayerMovement.isOnFloor == true && (Time.time - startTime) > 1.3f) {
			text.text = "Press!";
		}

	}//end of Update()
}
