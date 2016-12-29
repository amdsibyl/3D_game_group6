using UnityEngine;
using System.Collections;
public class ColorChange : MonoBehaviour {
	public Material material;
	public static int colorMode = 0;
	public static bool colorUpdateFlag = false;
	int[] nowColorRgb = new int[3]{15,104,128};

	/* MODE 0:Normal */
	public Color NormalColor1 = new Color (0,192,242);
	public Color NormalColor2 = new Color (15,104,128);
	/* MODE 1:Green */
	public Color GreenColor1 = new Color (94,156,218);
	public Color GreenColor2 = new Color (94,156,218);
	/* MODE 2:Red */
	public Color RedColor1 = new Color (94,156,218);
	public Color RedColor2 = new Color (94,156,218);

	Color NowColor = new Color (15,104,128);

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
	void SetRgb(int r, int g, int b){
		nowColorRgb [0] = r;
		nowColorRgb [1] = g;
		nowColorRgb [2] = b;
	}
}
