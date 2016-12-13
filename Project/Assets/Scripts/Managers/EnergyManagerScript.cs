using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyManagerScript : MonoBehaviour {
	public float maxEnergy;
	public float energy;

	public float startTime;
	public float endTime;

	public Image bar;
	private float level;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		bool UpdateFlag = false;
			/*
			energy = Time.time - startTime;
			if (energy > maxEnergy)
				energy %= maxEnergy;
			//level = ((int)energy) / maxEnergy;
			level = energy / maxEnergy;
			bar.fillAmount = level * 0.5f;
			*/

		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);

			// Handle finger movements based on touch phase.
			switch (touch.phase) {
			// Record initial touch position.
			case TouchPhase.Began:
				Debug.Log ("Start");
				//startPos = touch.position;
				startTime = Time.time;
				UpdateFlag = true;
				break;

			// Determine direction by comparing the current touch position with the initial one.
			case TouchPhase.Moved:
				
				break;

			// Report that a direction has been chosen when the finger is lifted.
			case TouchPhase.Ended:
				Debug.Log ("End");
				break;
			}
			if (UpdateFlag == true) {
				energy = Time.time - startTime;
				if (energy > maxEnergy)
					energy -= maxEnergy;
				level = energy / maxEnergy;
				bar.fillAmount = level * 0.5f;
			}
		}

	}
}
