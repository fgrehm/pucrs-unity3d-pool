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
				var objectName = collision.gameObject.name;
				GameObject.Destroy(collision.gameObject);

				var ballNumber = int.Parse(objectName.Replace("Ball", ""));
				PoolGameController.GameInstance.BallPocketed(ballNumber);
			}
		}

		if (cueBall.transform.name == collision.gameObject.name) {
			cueBall.transform.position = originalCueBallPosition;
		}
	}
}
