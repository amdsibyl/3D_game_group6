using UnityEngine;
using System.Collections;
public class ColorChange : MonoBehaviour {
	public Material material;
	//public MicrophoneInput micInput;
	const float maxLoud = 0.2f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		float random = Random.Range (0.0001f, 0.9f);
		//float value = (maxLoud - micInput.MicLoudness)/maxLoud;
		float value = (maxLoud - random) / maxLoud;
		Debug.Log (value);
		if (value < 0)
			value = 0;

		material.color = new Color (value, (1 - value), (1 - value));
	}
}
