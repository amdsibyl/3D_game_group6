using UnityEngine;
using System.Collections;

public class ModeManager : MonoBehaviour {

	Rigidbody player;
	public int NowLevel = 1;
	public GameObject[] Level;
	public Vector3[] startCoordinate;

	void Start () {
		player = GetComponent<Rigidbody> ();

		for (int i = 0; i < Level.Length; i++) {
			if (i+1 == NowLevel) {
				Level [i].SetActive (true);
				player.transform.position = startCoordinate [i];
			} 
			else {
				Level [i].SetActive (false);
			}
		}
	}
	
	void Update () {
	}
}
