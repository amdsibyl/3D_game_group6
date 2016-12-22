using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using TouchScript.Gestures;
//using TouchScript.Hit;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	public int mode = 0;
	bool MoveFlag = false;
	Vector3 movement;
	Rigidbody playerRigidbody;
//	float radius;
//	Animator anim;
//	int floorMask;
//	float camRayLength = 100f;

	void Awake(){
//		floorMask = LayerMask.GetMask ("Floor");
//		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
		TextManager.mode = mode;
//		radius = GetComponent<SphereCollider> ().radius;
	}

	void Update(){
		
		if (EnergyManagerScript.UpdateFlag == true) {
			MoveFlag = true;
			//OnCollisionEnter();
		} else if (MoveFlag == true) {
			playerRigidbody.velocity = new Vector3 (0, 9.8f * 0.9f / 2.0f, 0);

			if (TextManager.mode == 0) {
				//number of steps

				switch(TextManager.nowDirection){

				case 0: //forward
					playerRigidbody.transform.DOLocalMoveZ (playerRigidbody.transform.position.z + TextManager.data * 2f, 2f);
					break;

				case 1: //right
					playerRigidbody.transform.DOLocalMoveX (playerRigidbody.transform.position.x + TextManager.data * 2f, 2f);
					break;

				case 2: //back
					playerRigidbody.transform.DOLocalMoveZ (playerRigidbody.transform.position.z - TextManager.data * 2f, 2f);
					break;

				case 3: //left
					playerRigidbody.transform.DOLocalMoveX (playerRigidbody.transform.position.x - TextManager.data * 2f, 2f);
					break;
				}

			} 
			else {
				//change direction
				switch(TextManager.nowDirection){
					case 0: //forward
						playerRigidbody.transform.DOLocalMoveZ (playerRigidbody.transform.position.z + 2f , 2f);
						break;

					case 1: //right
						playerRigidbody.transform.DOLocalMoveX (playerRigidbody.transform.position.x + 2f, 2f);
						break;

					case 2: //back
						playerRigidbody.transform.DOLocalMoveZ (playerRigidbody.transform.position.z - 2f , 2f);
						break;

					case 3: //left
						playerRigidbody.transform.DOLocalMoveX (playerRigidbody.transform.position.x - 2f, 2f);
						break;
				}
			
			}

			MoveFlag = false;
		}


	}//end  of Update()
/*		
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "green_right")
		{
			Debug.Log("green_right");
		}
		else if (collision.gameObject.tag == "green_down")
		{
			Debug.Log("green_down");
		}
		else if (collision.gameObject.tag == "green_left")
		{
			Debug.Log("green_left");
		}
		else if (collision.gameObject.tag == "green_up")
		{
			Debug.Log("green_up");
		}


		else if (collision.gameObject.tag == "GREEN")
		{
			Debug.Log("green");
		}
	}
*/

/*
	void FixedUpdate(){
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		Move (h, v);
//		Turning ();
//		Animating (h, v);
	}

	void Move(float h,float v){
		float jumpSpeed = 3.0f;
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		//playerRigidbody.AddForce(Vector3.up * jumpSpeed);
		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Turning(){
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit floorHit;

		if(Physics.Raycast(camRay,out floorHit,camRayLength,floorMask)){
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation (newRotation);
		}
			
	}
	void Animating(float h,float v){
		bool walking = h!=0f || v!=0f;
		anim.SetBool ("IsWalking", walking);

	}
*/
}
