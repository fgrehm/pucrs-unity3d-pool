using UnityEngine;
using System.Collections;

public class PocketsController : MonoBehaviour {
	public GameObject redBalls;
	public GameObject cueBall;

	void OnCollisionEnter(Collision collision) {
		foreach (var transform in redBalls.GetComponentsInChildren<Transform>())
			if (transform.name == collision.gameObject.name)
				Debug.Log("Red ball dropped");

		if (cueBall.transform.name == collision.gameObject.name)
			Debug.Log("Cue ball dropped");

		GameObject.Destroy(collision.gameObject);
	}
}
