using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using TouchScript.Gestures;
//using TouchScript.Hit;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
	public int mode = 1;
	bool MoveFlag = false;
	bool CollisionFlag = false;
	int[] CollisionTmp = new int[3];
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

			}//end of else

			if (CollisionFlag == true) {
				TextManager.mode = 1;
				TextManager.data = CollisionTmp [1];
				TextManager.nowDirection = CollisionTmp [2];
				CollisionFlag = false;
			}
			MoveFlag = false;
			//mode = TextManager.mode;
		}

	}//end of Update()

	void Record(int i,int j,int k){
		CollisionTmp [0] = i;	
		CollisionTmp [1] = j;
		CollisionTmp [2] = k;
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "green_up") {
			Debug.Log ("green_up");
			Record (TextManager.mode, TextManager.data, TextManager.nowDirection);
			TextManager.mode = 0;
			TextManager.data = 0;
			TextManager.nowDirection = 0;
			CollisionFlag = true;
		} 	
		else if (collision.gameObject.tag == "green_right") {
			Debug.Log ("green_right");
			Record (TextManager.mode, TextManager.data, TextManager.nowDirection);
			TextManager.mode = 0;
			TextManager.data = 1;
			TextManager.nowDirection = 1;
			CollisionFlag = true;
		} 
		else if (collision.gameObject.tag == "green_down") {
			Debug.Log ("green_down");
			Record (TextManager.mode, TextManager.data, TextManager.nowDirection);
			TextManager.mode = 0;
			TextManager.data = 2;
			TextManager.nowDirection = 2;
			CollisionFlag = true;
		} 
		else if (collision.gameObject.tag == "green_left") {
			Debug.Log ("green_left");
			Record (TextManager.mode, TextManager.data, TextManager.nowDirection);
			TextManager.mode = 0;
			TextManager.data = 3;
			TextManager.nowDirection = 3;
			CollisionFlag = true;
		}

	}


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
