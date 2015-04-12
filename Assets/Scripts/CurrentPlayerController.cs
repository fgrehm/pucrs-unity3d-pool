using UnityEngine;
using System.Collections;

public class CurrentPlayerController : MonoBehaviour {
	public GameObject cueBall;
	public int multiplier;

	void Update () {
		//Debug.Log (cueBall.rigidbody.IsSleeping ());
		Debug.Log (Input.GetButton("Fire1"));
		if (Input.GetButton("Fire1") && cueBall.rigidbody.IsSleeping()) {
			Strike ();
		}
	}

	void Strike() {
		float z = 0.0f, x = 0.0f;

		x = Input.GetAxis("Horizontal");
		z = Input.GetAxis("Vertical");
	
		Vector3 force = new Vector3(x * multiplier, 0.0f, z * multiplier);
		cueBall.rigidbody.AddForce(force);
	}
}
