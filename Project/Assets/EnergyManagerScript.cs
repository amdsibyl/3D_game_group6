using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyManagerScript : MonoBehaviour {
	public float maxEnergy;
	public float energy;
	public int speedLevel = 10;

	private float startTime;
	private bool UpdateFlag = false;

	public Image bar;
	private float level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);

			// Handle finger movements based on touch phase.
			switch (touch.phase) {
			// Record initial touch position.
			case TouchPhase.Began:
				//startPos = touch.position;
				startTime = Time.time;
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
			if (UpdateFlag == true) {
				 
				energy = Mathf.Pow (Time.time - startTime, 2) * speedLevel;

				if (energy / maxEnergy >= 1.1) {
					startTime = Time.time;
					energy = 0;
				}
				level = energy / maxEnergy;
				bar.fillAmount = level * 0.5f;

			}
		}

	//	level = energy / maxEnergy;
	//	bar.fillAmount = level * 0.5f;
	}


}
