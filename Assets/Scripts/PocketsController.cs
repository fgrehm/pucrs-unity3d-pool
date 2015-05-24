using UnityEngine;
using System.Collections;

public class PocketsController : MonoBehaviour {
	public GameObject redBalls;
	public GameObject cueBall;

	private Vector3 originalCueBallPosition;

	void Start() {
		originalCueBallPosition = cueBall.transform.position;
	}

	void OnCollisionEnter(Collision collision) {
		foreach (var transform in redBalls.GetComponentsInChildren<Transform>()) {
			if (transform.name == collision.gameObject.name) {
				Debug.Log("Red ball dropped");
				GameObject.Destroy(collision.gameObject);
			}
		}

		if (cueBall.transform.name == collision.gameObject.name) {
			Debug.Log("Cue ball dropped");

			cueBall.transform.position = originalCueBallPosition;
		}
	}
}
