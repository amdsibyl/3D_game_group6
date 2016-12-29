using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyManagerScript : MonoBehaviour {

	public AudioSource pressAudio;
	public AudioSource releaseAudio;

	public float maxEnergy = 10;
	public float energy = 0;
	public int speedLevel = 10;
	public Image bar;

	public static bool UpdateFlag = false;
	public static bool Done = false;
	public static bool RedFlag = false;

	bool RedFirst = true;
	bool MouseClick = false;
	bool isTouch = false;

	float startTime;
	float div;
	int nowBlock;
	//int ctr = 0;


	void Start () {
		nowBlock = -1;
		energy = 0;
		bar.fillAmount = 0f;
		MouseClick = false;
		isTouch = false;
		//ctr = 0;
	}

	void Reset (){
		startTime = Time.time;
		energy = 0;
		nowBlock = 0;
		PlayerMovement.data = 0;
	}
	void Update () {
		if (RedFlag == true) {
			UpdateFlag = true;

			if (RedFirst == true) {
				Reset ();
				RedFirst = false;
			}

			//Debug.Log (Time.time - startTime);

			if ((Time.time - startTime) < 3.0f && PlayerMovement.isOnFloor == true && UIManager.QuitWindowOpen == false && LevelManager.LvupWindowOpen == false) {

				/*For Computer*/
				if (Input.GetMouseButtonDown (0) && MouseClick == false) {
					//print (Input.mousePosition);
					//ctr++;
					//Debug.Log ("Ctr:" + ctr);
					energy += 0.2f;
					MouseClick = true;
				} else if (Input.GetMouseButtonUp (0)) {
					MouseClick = false;
				}

				/*For Mobile*/
				if (Input.touchCount > 0) {
					Touch touch = Input.GetTouch (0);

					// Handle finger movements based on touch phase.
					switch (touch.phase) {
					// Record initial touch position.
					case TouchPhase.Began:
						if (isTouch == false) {
							energy += 0.2f;
							isTouch = true;
						}
						break;

						// Determine direction by comparing the current touch position with the initial one.
					case TouchPhase.Moved:
						break;

						// Report that a direction has been chosen when the finger is lifted.
					case TouchPhase.Ended:
						isTouch = false;
						break;
					}
				}
				div = energy / maxEnergy;
				bar.fillAmount = div * 0.5f;

				for (int i = 1; i < 10; i++) {
					if (div < 0.1 * i)
						break;
					else if (nowBlock == i - 1) {
						nowBlock++;
					}
					PlayerMovement.data = nowBlock;
				}


			}//end when timeout
			else if((Time.time - startTime) >= 3.0f){
				//Debug.Log ("Timeout");
				RedFlag = false;
				Done = true;
				UpdateFlag = false;
			}
				
		}//end of redFlag
		else {
			/*For Computer*/
			if (Input.GetMouseButtonDown (0) && PlayerMovement.isOnFloor == true && UIManager.QuitWindowOpen == false && LevelManager.LvupWindowOpen == false) {
				//print (Input.mousePosition);
				pressAudio.Play ();
				if (Input.mousePosition.x < 200 && (Screen.height - Input.mousePosition.y) < 70) {
					//back button
				} else {
					Reset ();
					UpdateFlag = true;
				}
			} else if (Input.GetMouseButtonUp (0)) {
				UpdateFlag = false;
			}

			/*For Mobile*/
			if (Input.touchCount > 0) {
				pressAudio.Play ();
				Touch touch = Input.GetTouch (0);

				// Handle finger movements based on touch phase.
				switch (touch.phase) {
				// Record initial touch position.
				case TouchPhase.Began:
					if (PlayerMovement.isOnFloor == true && UIManager.QuitWindowOpen == false && LevelManager.LvupWindowOpen == false) {
						if (touch.position.x < 200 && (Screen.height - touch.position.y) < 70) {
							//back button
						} else {
							Reset ();
							UpdateFlag = true;
						}
					}
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
				//Debug.Log (Time.time - startTime);
				div = energy / maxEnergy;

				if ((div >= 0.4 && nowBlock == 0) || (div >= 0.7 && nowBlock == 1) || (div >= 0.9 && nowBlock == 2)) {
					nowBlock++;
				}
				PlayerMovement.data = nowBlock;

				if (div >= 1.1) {
					Reset ();
				}
				//Debug.Log ("Energy:"+energy);
				//div = energy / maxEnergy;
				bar.fillAmount = div * 0.5f;
				Done = true;

			}

		}
		if (UpdateFlag ==false && Done == true) {
			pressAudio.Stop ();
			releaseAudio.Play ();
			Start ();
		}
			
	}//end of Update
		
}
