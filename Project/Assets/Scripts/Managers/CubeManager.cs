using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour {
	public ParticleSystem particlesystem;
	void Start () {
		
	}

	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){

		if (collision.gameObject.tag == "Player")
		{
			particlesystem.Play ();
		}

	}


}
