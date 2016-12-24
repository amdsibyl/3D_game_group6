using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using TouchScript.Gestures;
//using TouchScript.Hit;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
	/* Mode 0: Decide the steps
	   Mode 1: Change direction */
	public static int mode = 1;
	public static int data;
	public static int nowDirection = 0;

	public float speed = 30f;
	bool CollisionFlag = false;
	int[] CollisionTmp = new int[2];
	Vector3 movement;
	Rigidbody playerRigidbody;
	Vector3 movementX;
	Vector3 movementZ;

	void Awake(){
		playerRigidbody = GetComponent<Rigidbody> ();
		mode = 1;
		data = 0;
	}

	void Update(){

		if (EnergyManagerScript.UpdateFlag == false && EnergyManagerScript.Done == true) {
			playerRigidbody.velocity = new Vector3 (0, 9.8f * 0.9f / 2.0f, 0);

			if (mode == 0) {
				//Debug.Log ("mode0:"+data);

				movementX = new Vector3(data * 2f,0,0);
				movementZ = new Vector3(0,0,data * 2f);

				//number of steps
				switch(nowDirection){

				case 0: //forward
					//playerRigidbody.transform.DOMoveZ (playerRigidbody.transform.position.z + data * 2f, 2f);
					playerRigidbody.transform.DOJump(playerRigidbody.transform.position + movementZ, 1, 1, 1.2f, false);
					break;

				case 1: //right
					//playerRigidbody.transform.DOMoveX (playerRigidbody.transform.position.x + data * 2f, 2f);
					playerRigidbody.transform.DOJump(playerRigidbody.transform.position + movementX, 1, 1, 1.2f, false);
					break;

				case 2: //back
					//playerRigidbody.transform.DOMoveZ (playerRigidbody.transform.position.z - data * 2f, 2f);
					playerRigidbody.transform.DOJump(playerRigidbody.transform.position - movementZ, 1, 1, 1.2f, false);
					break;

				case 3: //left
					//playerRigidbody.transform.DOMoveX (playerRigidbody.transform.position.x - data * 2f, 2f);
					playerRigidbody.transform.DOJump(playerRigidbody.transform.position - movementX, 1, 1, 1.2f, false);
					break;
				}

				if (CollisionFlag == true) {
					mode = 1;
					CollisionFlag = false;
				}

			} 
			else {
				//Debug.Log ("mode1:"+data);
				movementX = new Vector3(2f,0,0);
				movementZ = new Vector3(0,0,2f);

				//change direction
				switch(data){
					
					case 0: //forward
						//playerRigidbody.transform.DOLocalMoveZ (playerRigidbody.transform.position.z + 2f , 2f);
						playerRigidbody.transform.DOJump(playerRigidbody.transform.position + movementZ, 1, 1, 1.2f, false);	
						break;

					case 1: //right
						//playerRigidbody.transform.DOLocalMoveX (playerRigidbody.transform.position.x + 2f , 2f);
						playerRigidbody.transform.DOJump(playerRigidbody.transform.position + movementX, 1, 1, 1.2f, false);
						break;

					case 2: //back
						//playerRigidbody.transform.DOLocalMoveZ (playerRigidbody.transform.position.z - 2f , 2f);
						playerRigidbody.transform.DOJump(playerRigidbody.transform.position - movementZ, 1, 1, 1.2f, false);
						break;

					case 3: //left
						//playerRigidbody.transform.DOLocalMoveX (playerRigidbody.transform.position.x - 2f, 2f);
						playerRigidbody.transform.DOJump(playerRigidbody.transform.position - movementX, 1, 1, 1.2f, false);
						break;

					default:
						break;

				}
				nowDirection = data;

			}//end of else

			EnergyManagerScript.Done = false;
		}

	}//end of Update()


	void OnCollisionEnter (Collision collision)
	{

		if (collision.gameObject.tag == "green_up") {
			//Debug.Log ("green_up");
			mode = 0;
			nowDirection = 0;
			CollisionFlag = true;
		} 	
		else if (collision.gameObject.tag == "green_right") {
			//Debug.Log ("green_right");
			mode = 0;
			nowDirection = 1;
			CollisionFlag = true;
		} 
		else if (collision.gameObject.tag == "green_down") {
			//Debug.Log ("green_down");
			mode = 0;
			nowDirection = 2;
			CollisionFlag = true;
		} 
		else if (collision.gameObject.tag == "green_left") {
			//Debug.Log ("green_left");
			mode = 0;
			nowDirection = 3;
			CollisionFlag = true;
		}

	}//end of OnCollisionEnter()

}
