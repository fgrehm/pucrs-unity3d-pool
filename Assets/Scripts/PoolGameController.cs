using UnityEngine;
using System.Collections;

public class PoolGameController : MonoBehaviour {
	public GameObject cue;
	public GameObject cueBall;
	public GameObject redBalls;
	public GameObject mainCamera;
	public float maxForce;
	public float minForce;
	public Vector3 strikeDirection;

	private Vector3 cameraOffset;
	private Vector3 cueOffset;
	private Quaternion cameraRotation;
	private Quaternion cueRotation;

	private IGameObjectState currentState;

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

		currentState = new GameStates.WaitingForStrikeState(this);
	}
	
	// Update is called once per frame
	void Update () {
		var body = cueBall.GetComponent<Rigidbody>();

		if (Input.GetButton("Fire1") && body.IsSleeping()) {
			body.AddForce(strikeDirection * maxForce);
			cue.GetComponent<Renderer>().enabled = false;
			currentState = new GameStates.StrikingState(this);

			cameraOffset = cueBall.transform.position - mainCamera.transform.position;
			cameraRotation = mainCamera.transform.rotation;
			cueOffset = cueBall.transform.position - cue.transform.position;
			cueRotation = cue.transform.rotation;

		} else if (Input.GetButton("Fire2") && body.IsSleeping()) {
			body.AddForce(strikeDirection * minForce);
			cue.GetComponent<Renderer>().enabled = false;
			currentState = new GameStates.StrikingState(this);

			cameraOffset = cueBall.transform.position - mainCamera.transform.position;
			cameraRotation = mainCamera.transform.rotation;
			cueOffset = cueBall.transform.position - cue.transform.position;
			cueRotation = cue.transform.rotation;

		} else if (currentState is GameStates.StrikingState && body.IsSleeping()) {
			currentState = new GameStates.WaitingForStrikeState(this); 
		}

		currentState.Update();
	}

	void FixedUpdate() {
		currentState.FixedUpdate();
	}

	void LateUpdate() {
		currentState.LateUpdate();

		if (!cueBall.GetComponent<Rigidbody>().IsSleeping()) {
			mainCamera.transform.position = cueBall.transform.position - cameraOffset;
			mainCamera.transform.rotation = cameraRotation;

			cue.transform.position = cueBall.transform.position - cueOffset;
			cue.transform.rotation = cueRotation;
		}
	}
}
