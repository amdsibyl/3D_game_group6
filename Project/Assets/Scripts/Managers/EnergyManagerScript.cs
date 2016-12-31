using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyManagerScript : MonoBehaviour {

	//screen:(200,320)

	public AudioSource pressAudio;
	public AudioSource releaseAudio;
	public GameObject pressPanel;

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
	bool isPlaying = false;

	float startTime;
	float div;
	int nowBlock;
	float energyUnit = 0.15f;


	void Start () {
		nowBlock = -1;
		energy = 0;
		bar.fillAmount = 0f;
		MouseClick = false;
		isTouch = false;
		//print(Screen.width+","+Screen.height);
		//print("#"+(35* Screen.width/199)+","+(35* Screen.height/319));
	}

	void Reset (){
		startTime = Time.time;
		energy = 0;
		nowBlock = 0;
		PlayerMovement.data = 0;
		//isPlaying = false;
	}
	void Update () {
		if (RedFlag == true) {
			UpdateFlag = true;
			pressPanel.SetActive(false);

			if (RedFirst == true) {
				startTime = Time.time;
				energy = 0;
				nowBlock = 1;
				PlayerMovement.data = 1;
				RedFirst = false;
			}

			//Debug.Log (Time.time - startTime);

			if ((Time.time - startTime) < 3.0f && PlayerMovement.isOnFloor == true && PlayerMovement.QuitWindowOpen == false && LevelManager.LvupWindowOpen == false && Resetter.ResetWindowOpen == false) {

				/*For Computer*/
				if (Input.GetMouseButtonDown (0) && MouseClick == false) {
					//print (Input.mousePosition);
					energy += energyUnit;
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
							energy += energyUnit;
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
					else if (nowBlock == i) {
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
			if (Input.GetMouseButtonDown (0) && PlayerMovement.isOnFloor == true && PlayerMovement.QuitWindowOpen == false && LevelManager.LvupWindowOpen == false) {
				//print (Input.mousePosition);
				//print (Screen.height - Input.mousePosition.y);


				if (Input.mousePosition.x < (35* Screen.width/199)  && (Screen.height - Input.mousePosition.y) < (35* Screen.height/319) ) {
					//pause button
				} else {
					
					if (isPlaying == false) {
						pressAudio.Play ();
						isPlaying = true;
					}
					pressPanel.SetActive(false);
					Reset ();
					UpdateFlag = true;

				}
			} else if (Input.GetMouseButtonUp (0)) {
				UpdateFlag = false;
			}

			/*For Mobile*/
			if (Input.touchCount > 0) {
				if (isPlaying == false) {
					pressAudio.Play ();
					isPlaying = true;
				}
				pressPanel.SetActive(false);
				Touch touch = Input.GetTouch (0);

				// Handle finger movements based on touch phase.
				switch (touch.phase) {
				// Record initial touch position.
				case TouchPhase.Began:
					if (PlayerMovement.isOnFloor == true && UIManager.QuitWindowOpen == false && LevelManager.LvupWindowOpen == false) {
						if (Input.mousePosition.x < (35* Screen.width/199)  && (Screen.height - Input.mousePosition.y) < (35* Screen.height/319) ) {
							//pause button
						} else {

							if (isPlaying == false) {
								pressAudio.Play ();
								isPlaying = true;
							}
							pressPanel.SetActive(false);
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
					pressAudio.Play ();
				}

				bar.fillAmount = div * 0.5f;
				Done = true;

			}

		}
		if (UpdateFlag == false && Done == true) {
			pressAudio.Stop ();
			if(PlayerMovement.isOnFloor == true)
				releaseAudio.Play ();
			Start ();
			isPlaying = false;
			//pressPanel.SetActive(true);
		}
			
	}//end of Update
		
}
