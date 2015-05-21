using UnityEngine;
using System.Collections;

public class PoolGameController : MonoBehaviour {
	public GameObject cue;
	public GameObject cueBall;
	public GameObject redBalls;
	public GameObject mainCamera;
	public float maxForce;
	public float minForce;

	private Vector3 strikeDirection;
	private Vector3 cameraOffset;
	private Vector3 cueOffset;
	private Quaternion cameraRotation;
	private Quaternion cueRotation;

	// Use this for initialization
	void Start () {
		strikeDirection = Vector3.forward;

		cameraOffset = cueBall.transform.position - mainCamera.transform.position;
		cameraRotation = mainCamera.transform.rotation;

		cueOffset = cueBall.transform.position - cue.transform.position;
		cueRotation = cue.transform.rotation;

		cueBall.GetComponent<Rigidbody>().sleepThreshold = 0.1f;
		foreach (var rigidbody in redBalls.GetComponentsInChildren<Rigidbody>())
			rigidbody.sleepThreshold = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		var body = cueBall.GetComponent<Rigidbody>();

		if (Input.GetButton("Fire1") && body.IsSleeping()) {
			body.AddForce(strikeDirection * maxForce);
			cue.GetComponent<Renderer>().enabled = false;
		} else if (Input.GetButton("Fire2") && body.IsSleeping()) {
			body.AddForce(strikeDirection * minForce);
			cue.GetComponent<Renderer>().enabled = false;
		} else if (body.IsSleeping()) {
			cue.GetComponent<Renderer>().enabled = true;
			var x = Input.GetAxis("Horizontal");
			if (x != 0) {
				var angle = x * 75 * Time.deltaTime;
				strikeDirection = Quaternion.AngleAxis(angle, Vector3.up) * strikeDirection;
				mainCamera.transform.RotateAround(cueBall.transform.position, Vector3.up, angle);
				cue.transform.RotateAround(cueBall.transform.position, Vector3.up, angle);

				cueRotation = cue.transform.rotation;
				cueOffset = cueBall.transform.position - cue.transform.position;

				cameraRotation = mainCamera.transform.rotation;
				cameraOffset = cueBall.transform.position - mainCamera.transform.position;
			}
			Debug.DrawLine(cueBall.transform.position, cueBall.transform.position+strikeDirection*10);
		}
	}

	void LateUpdate() {
		if (!cueBall.GetComponent<Rigidbody>().IsSleeping()) {
			mainCamera.transform.position = cueBall.transform.position - cameraOffset;
			mainCamera.transform.rotation = cameraRotation;

			cue.transform.position = cueBall.transform.position - cueOffset;
			cue.transform.rotation = cueRotation;
		}
	}
}
