using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCubeManager : MonoBehaviour {

	private int CollisionCount;
	public ParticleSystem particlesystem;
	// Use this for initialization
	void Start () {
		CollisionCount = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision){

		if (collision.gameObject.tag == "Player" && CollisionCount==1)
		{
			particlesystem.Play ();
			CollisionCount--;
		}

	}
}
