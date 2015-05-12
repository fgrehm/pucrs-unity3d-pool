using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject cueBall;
	private Vector3 offset;
	
	void Start () {
		offset = transform.position - cueBall.transform.position;
	}
	
	void LateUpdate () {
		transform.position = cueBall.transform.position + offset;
		transform.LookAt(cueBall.transform);
	}
}
