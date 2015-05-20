using UnityEngine;
using System.Collections;

public class SnookerBallController : MonoBehaviour {
	private Rigidbody body;

	void Start() {
		body = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		var velocity = body.velocity;
		if (velocity.y > 0) {
			velocity.y *= 0.8f;
			body.velocity = velocity;
		}
	}
}
