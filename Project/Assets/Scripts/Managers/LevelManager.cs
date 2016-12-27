using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelManager : MonoBehaviour {

	Rigidbody player;
	public static int NowLevel = 1;
	public GameObject[] Level;
	public Vector3[] startCoordinate;
	/* LEVEL1:(3,5,2)
	 * LEVEL2:(5,5,2)
	 * LEVEL3:(1,5,0) */

	void Start () {
		player = GetComponent<Rigidbody> ();
		SetLevel ();
	}
	
	void Update () {
		
		if (PlayerMovement.LevelUpFlag == true) {
			if (NowLevel < 3) {
				++NowLevel;
				//print (NowLevel);
				TextManager.text.text = "Press!";
				SetLevel ();
				SceneManager.LoadScene("Proj01");

			} else {
				//Finish
				print("Finish!");

			}

			PlayerMovement.LevelUpFlag = false;
		}

	}

	void SetLevel(){

		for (int i = 0; i < Level.Length; i++) {
			if (i + 1 == NowLevel) {
				Level [i].SetActive (true);
			}
			else {
				Level [i].SetActive (false);
			}
		}
		player.transform.position = Vector3.MoveTowards(player.transform.position, startCoordinate[NowLevel-1] , 6f);
		//SceneManager.LoadScene("Proj01");

	}

}
