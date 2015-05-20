using UnityEngine;
using System.Collections;

public class CurrentPlayerController : MonoBehaviour {
	public GameObject cue;
	public GameObject cueBall;
	public GameObject redBalls;
	public GameObject mainCamera;
	public float sleepThreshold;

	// TODO: This is going to be handled by the script instead of being passed in
	public float strikeSpeed;
	public float multiplier;
	private State currentState;
	private Vector3 cueCameraOffset;

	enum State {
		WaitingForStrike,
		Striking,
		WaitingForTurnToEnd
	}

	void Start () {
		currentState = State.WaitingForStrike;
		cueBall.GetComponent<Rigidbody>().sleepThreshold = sleepThreshold;
		foreach (var ballRigidBody in redBalls.GetComponentsInChildren<Rigidbody>()) 
			ballRigidBody.sleepThreshold = sleepThreshold;

		cueCameraOffset = mainCamera.transform.position - cue.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		switch (currentState) {
		case State.WaitingForStrike:
			HandleWaitingForStrikeUpdate();
			break;
		case State.Striking:
			HandleStrikingUpdate();
			break;
		case State.WaitingForTurnToEnd:
			HandleWaitingForTurnToEndUpdate();
			break;
		}
	}

	private void HandleWaitingForStrikeUpdate() {
		if (Input.GetButton ("Fire1")) {
			cue.SendMessage ("Strike", new CueController.StrikeMessage (strikeSpeed, -multiplier, cueBall));
			currentState = State.Striking;
		} else {
			var x = Input.GetAxis("Horizontal");
			cue.transform.RotateAround(cueBall.transform.position, Vector3.down, x * 75 * Time.deltaTime);
			mainCamera.transform.RotateAround(cueBall.transform.position, Vector3.down, x * 75 * Time.deltaTime);
		}
	}

	private void HandleStrikingUpdate() {
		if (cueBall.GetComponent<Rigidbody>().velocity != Vector3.zero) {
			mainCamera.SendMessage("FollowCueBall");
			currentState = State.WaitingForTurnToEnd;
		}
	}

	private void HandleWaitingForTurnToEndUpdate() {
		if (!ballsAreSleeping)
			return;

		currentState = State.WaitingForStrike;
		cue.SendMessage("Reset", cueBall);
		mainCamera.SendMessage("StopFollowingCueBall");
		mainCamera.transform.position = cue.transform.position + cueCameraOffset;
		mainCamera.transform.LookAt(cueBall.transform.position);
	}

	private bool ballsAreSleeping {
		get {
			if (!cueBall.GetComponent<Rigidbody>().IsSleeping()) 
				return false;

			foreach (var ballRigidBody in redBalls.GetComponentsInChildren<Rigidbody>())
				if (!ballRigidBody.IsSleeping()) 
					return false;

			return true;
		}
	}
}
