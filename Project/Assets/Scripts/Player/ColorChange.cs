using UnityEngine;
using System.Collections;
public class ColorChange : MonoBehaviour {
	public Material material;
	public Color color1;
	public Color color2;
	void Start () {

	}
		
	void Update () {
		material.color = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, 1));
	}
}
