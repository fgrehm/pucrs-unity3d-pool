using UnityEngine;
using System.Collections;

public class CueController : MonoBehaviour {
	public GameObject cueBall;
	public float velocity;

	private Vector3 force;
	private bool striking = false;
	private Vector3 positionOffset;

	void Start() {
		positionOffset = transform.position - cueBall.transform.position;
		force = Vector3.down * velocity;
		cueBall.rigidbody.sleepVelocity = 0f;
		cueBall.rigidbody.sleepAngularVelocity = 0f;
	}

	void FixedUpdate() {
//		Debug.Log(Time.frameCount + " sleeping " + cueBall.rigidbody.IsSleeping());
//		Debug.Log(Time.frameCount + " Striking " + striking);
//		Debug.Log(Time.frameCount + " velocit " + cueBall.rigidbody.velocity);
//		Debug.Log(Time.frameCount + " ang velo " + cueBall.rigidbody.angularVelocity);

		if (striking) {
			transform.Translate(force * Time.deltaTime);
		} else if (cueBall.rigidbody.IsSleeping()) {
			transform.position = cueBall.transform.position + positionOffset;
			transform.Translate(Vector3.up * velocity * 1.5f);
			striking = true;
			this.renderer.enabled = true;
			this.collider.enabled = true;
		}
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log("Collision");
		if (collision.gameObject != cueBall)
			return;

		striking = false;
		cueBall.rigidbody.AddForceAtPosition(collision.contacts[0].normal * -1500, collision.contacts[0].point);
		this.renderer.enabled = false;
		this.collider.enabled = false;
	}
}