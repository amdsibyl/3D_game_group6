using UnityEngine;
using System.Collections;

public class CameraPerlinShake : GenericShake {

	public float magnitude = 2f;
	public float frequency = 10f;
	public float seconds = 3f;
	private float startTime;

	void Update () {
		if (EnergyManagerScript.isPlaying) {
			ApplyShake (PerlinShake ());
		}
	}
	public Vector2 PerlinShake () {
		Vector2 result;
		float seed = Time.time * frequency;
		result.x = Mathf.Clamp01(Mathf.PerlinNoise (seed, 0f)) - 0.5f;
		result.y = Mathf.Clamp01(Mathf.PerlinNoise (0f, seed)) - 0.5f; 
		result = result * magnitude;
		return result;
	}
}
