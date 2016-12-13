using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Resetter : MonoBehaviour {
    public Rigidbody projectile;
    public float resetSpeed = 0.025f;

	void Start () {
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
            Reset();
	}

    void OnTriggerExit(Collider other) {
        if (other.GetComponent<Rigidbody>() == projectile)
            Reset();

    }
    void Reset() {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene("Proj01");
    }
}
