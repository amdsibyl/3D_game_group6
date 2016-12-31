using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCubeManager : MonoBehaviour {
	
	public ParticleSystem particleSystem;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision collision){
		particleSystem.Play ();

	}
}
