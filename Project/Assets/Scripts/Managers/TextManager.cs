using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManager : MonoBehaviour {

	public static Text text;

	void Awake ()
	{
		text = GetComponent <Text> ();

	}
		
	void Update ()
	{ 
		if (EnergyManagerScript.UpdateFlag == true) {
			if (PlayerMovement.mode == 0) //number of steps
				text.text = "" + PlayerMovement.data;
			else {
				//change direction
				switch (PlayerMovement.data) {
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
			}
		}

	}//end of Update()
}
