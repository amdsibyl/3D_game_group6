using UnityEngine;
using System.Collections;
public class ColorChange : MonoBehaviour {
	public Material material;

	void Start () {

	}
		
	void Update () {
		material.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
	}
}
