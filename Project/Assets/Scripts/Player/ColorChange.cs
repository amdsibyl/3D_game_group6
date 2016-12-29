using UnityEngine;
using System.Collections;
public class ColorChange : MonoBehaviour {
	public Material material;
	public static int colorMode = 0;
	public static bool colorUpdateFlag = false;

	/* MODE 0:Normal */
	public Color NormalColor1 = new Color (55,208,248);
	public Color NormalColor2 = new Color (24,99,108);
	/* MODE 1:Green */
	public Color GreenColor1 = new Color (123,229,137);
	public Color GreenColor2 = new Color (43,131,55);
	/* MODE 2:Red */
	public Color RedColor1 = new Color (255,75,123);
	public Color RedColor2 = new Color (173,15,58);

	Color NowColor = new Color (24,99,108);

	void Start () {

	}
		
	void Update () {
		
		switch (colorMode) {

		case 0:
			if (colorUpdateFlag == true) {
				material.color = Color.Lerp (NowColor, NormalColor1, Time.time);
				NowColor = NormalColor2;
			}
			material.color = Color.Lerp (NormalColor1, NormalColor2, Mathf.PingPong (Time.time, 1));
			break;

		case 1:
			if(colorUpdateFlag == true){
				material.color = Color.Lerp (NowColor, GreenColor1, Time.time);
				NowColor = GreenColor2;
			}
			material.color = Color.Lerp (GreenColor1, GreenColor2, Mathf.PingPong (Time.time, 1));
			break;
		
		case 2:
			if(colorUpdateFlag == true){
				material.color = Color.Lerp (NowColor, RedColor1, Time.time);
				NowColor = RedColor2;
			}
			material.color = Color.Lerp (RedColor1, RedColor2, Mathf.PingPong (Time.time, 1));
			break;
		
		default:
			print ("ERROR");
			break;
		}

		colorUpdateFlag = false;

	}

}
