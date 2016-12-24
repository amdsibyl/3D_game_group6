using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject gameobj;
	Rigidbody player;
	public static int NowLevel = 1;
	public GameObject[] Level;
	public Vector3[] startCoordinate;

	void Start () {
		player = GetComponent<Rigidbody> ();
		gameobj = GetComponent<GameObject> ();
		Show ();
	}
	
	void Update () {
		
		if (PlayerMovement.LevelUpFlag == true) {
			if (NowLevel < 3) {
				++NowLevel;

				Show ();

			} else {
				//Finish
			}

			PlayerMovement.LevelUpFlag = false;
		}

	}

	void Show(){
		player.transform.position = startCoordinate [NowLevel-1];
		for (int i = 0; i < Level.Length; i++) {
			if (i+1 == NowLevel) {
				//gameobj.transform.position = startCoordinate [i];
				Level [i].SetActive (true);

			} 
			else {
				Level [i].SetActive (false);
			}
		}

	}
}
