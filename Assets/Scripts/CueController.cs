using UnityEngine;
using System.Collections;

public class CueController : MonoBehaviour {
	public GameObject cueBall;
	public Camera mainCamera;
	public float velocity;

	private Vector3 force;
	private bool striking = false;
	private Vector3 positionOffset;
	private Quaternion originalRotation;

	void Start() {
		positionOffset = transform.position - cueBall.transform.position;
		originalRotation = transform.rotation;
		force = Vector3.down * velocity;
	}

	void FixedUpdate() {
		if (striking) {
			transform.Translate(force * Time.deltaTime);
		}
	}

	void Update() {
		if (!striking) {
			float x = Input.GetAxis("Horizontal");
			transform.RotateAround(cueBall.transform.position, Vector3.down, x * 75 * Time.deltaTime);
			mainCamera.transform.RotateAround(cueBall.transform.position, Vector3.down, x * 75 * Time.deltaTime);

			float y = Input.GetAxis("Vertical");
			transform.RotateAround(cueBall.transform.position, transform.right	, y * 75 * Time.deltaTime);
		}
	}

	void OnCollisionEnter(Collision collision) {
		Debug.Log("Collision");
		if (collision.gameObject != cueBall)
			return;

		striking = false;
		cueBall.rigidbody.AddForceAtPosition(collision.contacts[0].normal * -2500, collision.contacts[0].point);
		this.renderer.enabled = false;
		this.collider.enabled = false;
	}

	void Strike() {
		striking = true;
	}

	void Reset() {
		transform.rotation = originalRotation;
		transform.position = cueBall.transform.position + positionOffset;

		this.renderer.enabled = true;
		this.collider.enabled = true;
	}
}