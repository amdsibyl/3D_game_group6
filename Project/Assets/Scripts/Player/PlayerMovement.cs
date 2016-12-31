using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//using TouchScript.Gestures;
//using TouchScript.Hit;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
	/* Mode 0: Decide the steps
	   Mode 1: Change direction
	   Mode 2: Red mode(steps:0 ~ 10) */
	public static int mode = 1;
	public static int data;
	public static int nowDirection = 0;

	public float speed = 30f;
	bool CollisionFlag = false;

	Vector3 movement;
	Rigidbody playerRigidbody;
	Vector3 movementX;
	Vector3 movementZ;

	public Button pause;
	public Button cancel;
	public Button restart;
	public Button home;
	public GameObject quitWindow;
	public static bool QuitWindowOpen = false;

	public static bool LevelUpFlag = false;
	public static bool isOnFloor = false;

	void Awake(){
		playerRigidbody = GetComponent<Rigidbody> ();
		mode = 1;
		data = 0;
		pause.onClick.AddListener (PauseOnClick);
		cancel.onClick.AddListener (CancelOnClick);
		restart.onClick.AddListener (RestartOnClick);
		home.onClick.AddListener (HomeOnClick);
		quitWindow.SetActive (false);
	}

	void Update(){

		if (EnergyManagerScript.UpdateFlag == false && EnergyManagerScript.Done == true) {
			playerRigidbody.velocity = new Vector3 (0, 9.8f * 0.9f / 2.0f, 0);
			ScoreManager.step -= 1;

			if (mode == 0) {
				//Debug.Log ("mode0:"+data);

				movementX = new Vector3(data * 2f,0,0);
				movementZ = new Vector3(0,0,data * 2f);

				//number of steps
				switch(nowDirection){

				case 1: //forward
					//playerRigidbody.transform.DOMoveZ (playerRigidbody.transform.position.z + data * 2f, 2f);
					playerRigidbody.transform.DOJump(playerRigidbody.transform.position + movementZ, 1, 1, 1.2f, false);
					break;

				case 2: //right
					//playerRigidbody.transform.DOMoveX (playerRigidbody.transform.position.x + data * 2f, 2f);
					playerRigidbody.transform.DOJump(playerRigidbody.transform.position + movementX, 1, 1, 1.2f, false);
					break;

				case 3: //back
					//playerRigidbody.transform.DOMoveZ (playerRigidbody.transform.position.z - data * 2f, 2f);
					playerRigidbody.transform.DOJump(playerRigidbody.transform.position - movementZ, 1, 1, 1.2f, false);
					break;

				case 0: //left
					//playerRigidbody.transform.DOMoveX (playerRigidbody.transform.position.x - data * 2f, 2f);
					playerRigidbody.transform.DOJump(playerRigidbody.transform.position - movementX, 1, 1, 1.2f, false);
					break;
				}
				Handheld.Vibrate();
				if (CollisionFlag == true) {
					mode = 1;
					CollisionFlag = false;
				}

			} 
			else if (mode == 1) {
				//Debug.Log ("mode1:"+data);
				movementX = new Vector3(2f,0,0);
				movementZ = new Vector3(0,0,2f);

				//change direction
				switch(data){
					
					case 1: //forward
						//playerRigidbody.transform.DOLocalMoveZ (playerRigidbody.transform.position.z + 2f , 2f);
						playerRigidbody.transform.DOJump(playerRigidbody.transform.position + movementZ, 1, 1, 1.2f, false);	
						break;

					case 2: //right
						//playerRigidbody.transform.DOLocalMoveX (playerRigidbody.transform.position.x + 2f , 2f);
						playerRigidbody.transform.DOJump(playerRigidbody.transform.position + movementX, 1, 1, 1.2f, false);
						break;

					case 3: //back
						//playerRigidbody.transform.DOLocalMoveZ (playerRigidbody.transform.position.z - 2f , 2f);
						playerRigidbody.transform.DOJump(playerRigidbody.transform.position - movementZ, 1, 1, 1.2f, false);
						break;

					case 0: //left
						//playerRigidbody.transform.DOLocalMoveX (playerRigidbody.transform.position.x - 2f, 2f);
						playerRigidbody.transform.DOJump(playerRigidbody.transform.position - movementX, 1, 1, 1.2f, false);
						break;

					default:
						break;

				}
				Handheld.Vibrate();
				nowDirection = data;

			}//end of mode 1
			else{
				//Red Mode
				//Debug.Log ("mode2:"+data);

				movementX = new Vector3(2f,0,0);
				movementZ = new Vector3(0,0,2f);

				switch (data) {
				case 1:
					playerRigidbody.transform.DOJump(playerRigidbody.transform.position + movementZ, 1, 1, 1.2f, false);
					break;
				case 2:
					playerRigidbody.transform.DOJump (playerRigidbody.transform.position + movementZ * 2, 1, 1, 1.2f, false);
					break;
				case 3:
					playerRigidbody.transform.DOJump(playerRigidbody.transform.position + movementZ * 2 + movementX, 1, 1, 1.2f, false);
					break;
				case 4:
					playerRigidbody.transform.DOJump(playerRigidbody.transform.position + movementZ * 2 + movementX * 2, 1, 1, 1.2f, false);
					break;
				case 5:
					playerRigidbody.transform.DOJump(playerRigidbody.transform.position + movementZ * 2 + movementX * 3, 1, 1, 1.2f, false);
					break;
				default:
					break;

				}

				if (CollisionFlag == true) {
					mode = 1;
					CollisionFlag = false;
				}

			}//end of mode 2

			EnergyManagerScript.Done = false;
		}

	}//end of Update()


	void OnCollisionEnter (Collision collision)
	{
		isOnFloor = true;

		if (collision.gameObject.tag == "GREEN") {
			//Debug.Log ("green");
			if (ColorChange.colorMode != 1) {
				ColorChange.colorMode = 1;
				ColorChange.colorUpdateFlag = true;
			}
		}
		if (collision.gameObject.tag == "green_up") {
			//Debug.Log ("green_up");
			mode = 0;
			nowDirection = 1;
			CollisionFlag = true;
		} else if (collision.gameObject.tag == "green_right") {
			//Debug.Log ("green_right");
			mode = 0;
			nowDirection = 2;
			CollisionFlag = true;
		} else if (collision.gameObject.tag == "green_down") {
			//Debug.Log ("green_down");
			mode = 0;
			nowDirection = 3;
			CollisionFlag = true;
		} else if (collision.gameObject.tag == "green_left") {
			//Debug.Log ("green_left");
			mode = 0;
			nowDirection = 0;
			CollisionFlag = true;
		} else if (collision.gameObject.tag == "RED") {
			Debug.Log ("Red");
			EnergyManagerScript.RedFlag = true;
			mode = 2;
			CollisionFlag = true;
			if (ColorChange.colorMode != 2) {
				ColorChange.colorMode = 2;
				ColorChange.colorUpdateFlag = true;
			}

		} else if (collision.gameObject.tag == "NORMAL") {
			//Debug.Log ("Normal");
			if (ColorChange.colorMode != 0) {
				ColorChange.colorMode = 0;
				ColorChange.colorUpdateFlag = true;
			}

		} else if (collision.gameObject.tag == "End") {
			//Debug.Log ("End");
			LevelUpFlag = true;
			//print (LevelUpFlag);
		}

	}//end of OnCollisionEnter()

	void OnCollisionExit (Collision collision)
	{
		isOnFloor = false;
	}

	void PauseOnClick(){
		//Debug.Log ("pause!");
		Time.timeScale = 0;
		quitWindow.SetActive (true);
		QuitWindowOpen = true;
	}

	void CancelOnClick(){
		//Debug.Log ("CancelOnClick!");
		quitWindow.SetActive (false);
		QuitWindowOpen = false;
		Time.timeScale = 1;
	}

	void RestartOnClick(){
		//Debug.Log ("RestartOnClick!");
		//Resetter.ResetFlag = true;
		SceneManager.LoadScene("Proj01");
		ScoreManager.stepUpdate = true;
		Time.timeScale = 1;
		QuitWindowOpen = false;
	}

	void HomeOnClick(){
		//Debug.Log ("HomeOnClick!");
		//home
		Application.Quit ();
		//Resetter.ResetFlag = true;

		//Time.timeScale = 1;
		//QuitWindowOpen = false;
	}

}
