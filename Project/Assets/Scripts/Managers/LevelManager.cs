using UnityEngine;
using System.Collections;
using DG.Tweening;

public class LevelManager : MonoBehaviour {

	Rigidbody player;
	public static int NowLevel = 1;
	public GameObject[] Level;
	public Vector3[] startCoordinate;


	void Start () {
		player = GetComponent<Rigidbody> ();
		Show ();
	}
	
	void Update () {
		
		if (PlayerMovement.LevelUpFlag == true) {
			if (NowLevel < 3) {
				++NowLevel;
				//print (NowLevel);
				TextManager.text.text = "Press!";
				Show ();

			} else {
				//Finish

			}

			PlayerMovement.LevelUpFlag = false;
		}

	}

	void Show(){

		for (int i = 0; i < Level.Length; i++) {
			if (i+1 == NowLevel) {
				Level [i].SetActive (true);
				//player.transform.DOMove (startCoordinate [i] - player.transform.position, 0.5f, false);
				//player.transform.position = Vector3.MoveTowards(player.transform.position, startCoordinate [i] , 6f);
				player.transform.position = Vector3.Lerp(player.transform.position, startCoordinate [i] , 6f);
			} 
			else {
				Level [i].SetActive (false);
			}
		}

	}
}
