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
		particlesystem.Play ();

/*		if (collision.gameObject.tag == "Player")
		{
			Debug.Log("player");
		}
*/
	}


}
