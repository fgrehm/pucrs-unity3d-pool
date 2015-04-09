using UnityEngine;
using System.Collections;

public class CurrentPlayerController : MonoBehaviour {
	public GameObject whiteBall;

	void Update () {
		float z = 0.0f, x = 0.0f;

		if (Input.GetKeyUp(KeyCode.UpArrow)) {
			z = 1;
		} else if (Input.GetKeyUp(KeyCode.DownArrow)) {
			z = -1;
		} else if (Input.GetKeyUp(KeyCode.RightArrow)) {
			x = 1;
		} else if (Input.GetKeyUp(KeyCode.LeftArrow)) {
			x = -1;
		}
		int multiplier = 20;
		Vector3 force = new Vector3(x * multiplier, 0.0f, z * multiplier);
		whiteBall.rigidbody.AddForce(force, ForceMode.Impulse);
	}
}
