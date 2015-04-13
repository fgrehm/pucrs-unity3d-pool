using UnityEngine;
using System.Collections;

public class CurrentPlayerController : MonoBehaviour {
	public GameObject cueBall;
	public GameObject cue;

//	void Update () {
//		if (Input.GetButton("Fire1") && cueBall.rigidbody.IsSleeping()) {
//			Strike();
//		}
//	}
//
//	void Strike() {
//		float x = Input.GetAxis("Horizontal");
//		x = (float)System.Math.Ceiling(x);
//
//		float z = Input.GetAxis("Vertical");
//		z = (float)System.Math.Ceiling(z);
//
//		Debug.Log("x=" + x + " z="+z);
//
//		Vector3 force = new Vector3(x, 0.0f, z) * multiplier;
//		cueBall.rigidbody.AddForce(force, ForceMode.Acceleration);
//	}
}
