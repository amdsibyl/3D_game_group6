using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergyManagerScript : MonoBehaviour {
	public float maxEnergy;
	public float energy;
	public Image bar;
	private float level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		level = energy / maxEnergy;
		bar.fillAmount = level * 0.5f;
	}
}
