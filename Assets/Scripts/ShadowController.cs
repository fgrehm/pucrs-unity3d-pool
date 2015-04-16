using UnityEngine;
using System.Collections;

public class ShadowController : MonoBehaviour {
	private Quaternion originalRotation;
	private Vector3 offset;

	void Start() {
		originalRotation = transform.rotation;
		offset = transform.position - transform.parent.position;
	}

	void LateUpdate () {
		transform.rotation = originalRotation;
		transform.position = transform.parent.position + offset;
	}
}