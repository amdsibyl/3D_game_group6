using UnityEngine;
using System.Collections;

public class ModeManager : MonoBehaviour {

	Rigidbody player;
	public int mode = 1;
	public GameObject[] Level;
	public Vector3[] startCoordinate;
	/*
	public GameObject Level01;
	public GameObject Level02;
	public GameObject Level03;
	*/

	void Start () {
		player = GetComponent<Rigidbody> ();

		for (int i = 0; i < Level.Length; i++) {
			if (i+1 == mode) {
				Level [i].SetActive (true);
				player.transform.position = startCoordinate [i];
			} 
			else {
				Level [i].SetActive (false);
			}
		}
		/*
		if(mode==1){
			Level01.SetActive(true);
			Level02.SetActive(false);
			Level03.SetActive(false);
			player.transform.position = new Vector3(3,5,2);
		}
		else if(mode==2){
			Level02.SetActive(true);
			Level01.SetActive(false);
			Level03.SetActive(false);
			player.transform.position = new Vector3(5,5,2);
		}
		else if(mode==3){
			Level03.SetActive(true);
			Level02.SetActive(false);
			Level01.SetActive(false);
			player.transform.position = new Vector3(1,5,0);
		}
		*/

	}
	
	void Update () {
	}
}
