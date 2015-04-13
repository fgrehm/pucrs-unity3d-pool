using UnityEngine;
using System.Collections;

public class CueController : MonoBehaviour {
	public GameObject cueBall;
	public float velocity;

	private Vector3 force;
	private bool striking = true;
	private Vector3 positionOffset;

	void Start() {
		positionOffset = transform.position - cueBall.transform.position;
		force = Vector3.down * velocity;
	}

	void FixedUpdate() {
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

	void OnTriggerEnter(Collider collider) {
		Debug.Log("Collision");
		if (collider.gameObject != cueBall)
			return;

		striking = false;
		var contactPoint = collider.ClosestPointOnBounds(this.collider.transform.position);
		cueBall.rigidbody.AddForceAtPosition(Vector3.forward * 1000, contactPoint);
		this.renderer.enabled = false;
		this.collider.enabled = false;
	}
}