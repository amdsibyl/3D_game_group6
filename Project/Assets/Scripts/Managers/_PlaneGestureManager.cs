using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Hit;
using DG.Tweening;

public class PlaneGestureManager : MonoBehaviour {

	public TapGesture singleTap;
	//public TapGesture doubleTap;

	public Rigidbody Player;

	void Start () {
		/*
		singleTap.Tapped += (object sender, System.EventArgs e) => {
			TouchHit hit;
			singleTap.GetTargetHitResult (out hit);

			Vector3 targetPoint = hit.Point;

			Player.velocity = new Vector3 (0, 9.8f * 1f / 2.0f, 0);
			Player.transform.DOLocalMoveX (targetPoint.x, 1f);
			Player.transform.DOLocalMoveZ (targetPoint.z, 1f);

		};
		/*


		/*
		singleTap.Tapped += (object sender, System.EventArgs e) => {

			TouchHit hit;
			singleTap.GetTargetHitResult (out hit);

			Vector3 targetPoint = hit.Point;
			targetPoint.y = Player.transform.position.y;

			Player.transform.DOMove (targetPoint, 0.5f);

		};

		doubleTap.Tapped += (object sender, System.EventArgs e) => {
			TouchHit hit;
			doubleTap.GetTargetHitResult (out hit);

			Vector3 targetPoint = hit.Point;

			Player.velocity = new Vector3 (0, 9.8f * 1f / 2.0f, 0);
			Player.transform.DOLocalMoveX (targetPoint.x, 1f);
			Player.transform.DOLocalMoveZ (targetPoint.z, 1f);

		};
		*/
	}

	// Update is called once per frame
	void Update () {

	}
}
