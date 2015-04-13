using UnityEngine;
using System.Collections;

public class CueController : MonoBehaviour {
	public GameObject cueBall;

	private Vector3 force;
	private bool striking = true;
	private Vector3 positionOffset;

	void Start() {
		positionOffset = transform.position - cueBall.transform.position;
		force = Vector3.down * 1.1f;
	}

	void Update() {
		if (striking)
			transform.Translate(force);
		else if (cueBall.rigidbody.IsSleeping()) {
			transform.position = cueBall.transform.position + positionOffset;
			transform.Translate(Vector3.up * 3f);
			striking = true;
		}
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log ("Collision");
		if (collision.gameObject != cueBall)
			return;

		striking = false;

		transform.rigidbody.velocity = new Vector3();
	}
}