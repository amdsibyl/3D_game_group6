using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDiamondManager : MonoBehaviour {
	public GameObject Diamond;
	public ParticleSystem ps;
	public AudioSource breakingSound;
	// Use this for initialization
	void Start () {
	//	Diamond.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){
		ps.Play ();
		breakingSound.Play ();
		Diamond.SetActive (false);

	}
}
