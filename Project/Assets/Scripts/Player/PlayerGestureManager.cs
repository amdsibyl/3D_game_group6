﻿//mobile control player's gesture
using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class PlayerGestureManager : MonoBehaviour {

	public TransformGesture transformGesture;
	private Rigidbody rigidBody;
	private Collider collider;

	void Start () {
		rigidBody = this.GetComponent<Rigidbody> ();
		collider = this.GetComponent<BoxCollider> ();

		transformGesture.TransformStarted += (object sender, System.EventArgs e) => {
			rigidBody.useGravity=false;
			rigidBody.velocity=Vector3.zero;
			collider.enabled=false;
		};

		transformGesture.Transformed += (object sender, System.EventArgs e) => {
			this.transform.position += transformGesture.DeltaPosition;
			this.transform.Rotate(new Vector3(0,0,1),transformGesture.DeltaRotation);
			this.transform.localScale*=transformGesture.DeltaScale;
		};
		transformGesture.TransformCompleted += (object sender, System.EventArgs e) => {
			rigidBody.useGravity=true;
			collider.enabled=true;
		};
	}

	// Update is called once per frame
	void Update () {

	}
}
