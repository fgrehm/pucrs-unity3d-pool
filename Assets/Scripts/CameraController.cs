using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject cueBall;

	private Vector3 offset;
	private bool followCueBall;
	
	void Start () {
		offset = transform.position - cueBall.transform.position;
	}
	
	void LateUpdate() {
		if (followCueBall) {
			transform.position = cueBall.transform.position + offset;
			transform.LookAt(cueBall.transform);
		}
	}

	void FollowCueBall() {
		followCueBall = true;
	}

	void StopFollowingCueBall() {
		followCueBall = false;
	}
}
