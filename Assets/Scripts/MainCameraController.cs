using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {
	public GameObject cueBall;
	private Vector3 offset;
	
	void Start () {
		offset = transform.position - cueBall.transform.position;
	}

	void LateUpdate () {
		transform.position = cueBall.transform.position + offset;
	}
}
