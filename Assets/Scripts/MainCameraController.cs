using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {
	public GameObject cueBall;
	private Vector3 offset;
	
	void Start () {
		offset = transform.position - cueBall.transform.position;
	}

	void Reset() {
		transform.position = cueBall.transform.position + offset;
		transform.LookAt(cueBall.transform.position);
	}
}
