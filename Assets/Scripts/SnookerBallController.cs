using UnityEngine;
using System.Collections;

public class SnookerBallController : MonoBehaviour {
	void FixedUpdate () {
		var rigidbody = GetComponent<Rigidbody>();
		if (rigidbody.velocity.y > 0) {
			var velocity = rigidbody.velocity;
			velocity.y *= 0.3f;
			rigidbody.velocity = velocity;
		}
	}
}
