using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redCubeManager : MonoBehaviour {
	public ParticleSystem particlesystem;
	void Start () {

	}

	void Update () {

	}

	void OnCollisionEnter(Collision collision){

		if (collision.gameObject.tag == "Player") {
			particlesystem.Play ();
		} 
	}
	void OnCollisionExit(Collision collision){
		particlesystem.Stop ();
	}
}
