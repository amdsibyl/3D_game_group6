using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyManagerScript : MonoBehaviour {
	public static float div;
	public float maxEnergy;
	public float energy;
	public int speedLevel;

	private float startTime;
	private bool UpdateFlag = false;

	public Image bar;
	private float level;
	private int nowBlock = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		/*For Computer*/
		if (Input.GetMouseButtonDown (0)) {
			startTime = Time.time;
			energy = 0;
			nowBlock = 0;
			TextManager.steps = 0;
			UpdateFlag = true;
		} else if (Input.GetMouseButtonUp (0)) {
			UpdateFlag = false;		
		}

		/*For Mobile*/
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);

			// Handle finger movements based on touch phase.
			switch (touch.phase) {
			// Record initial touch position.
			case TouchPhase.Began:
				startTime = Time.time;
				energy = 0;
				nowBlock = 0;
				TextManager.steps = 0;
				UpdateFlag = true;
				break;

				// Determine direction by comparing the current touch position with the initial one.
			case TouchPhase.Moved:
				break;

				// Report that a direction has been chosen when the finger is lifted.
			case TouchPhase.Ended:
				UpdateFlag = false;
				break;
			}
		}

		if (UpdateFlag == true) {
			energy = Mathf.Pow (Time.time - startTime, 2) * speedLevel;
			div = energy / maxEnergy;

			if (div >= 0.4 && nowBlock==0) {
				TextManager.steps = 1;
				nowBlock ++;
			} else if (div >= 0.7 && nowBlock==1) {
				TextManager.steps = 2;
				nowBlock ++;
			} else if (div >= 0.9 && nowBlock==2) {
				TextManager.steps = 3;
				nowBlock ++;
			}

			if (div >= 1.1) {
				startTime = Time.time;
				energy = 0;
				nowBlock = 0;
				TextManager.steps = 0;
			}

			level = energy / maxEnergy;
			bar.fillAmount = level * 0.5f;
		}

	}


}
