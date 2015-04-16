using UnityEngine;
using System.Collections;

public class CurrentPlayerController : MonoBehaviour {
	public GameObject cueBall;
	public GameObject cue;
	public Camera mainCamera;

	enum State {
		WaitingForStrike,
		Striking,
		WaitingForCueBallToStop
	}

	private State currentState = State.WaitingForStrike;

	void Start() {
		cueBall.rigidbody.sleepVelocity = 0.2f;
		cueBall.rigidbody.sleepAngularVelocity = 0.2f;
	}

	void Update() {
		if (currentState == State.WaitingForStrike) {
			if (Input.GetButton("Fire1")) {
				cue.SendMessage("Strike");
				currentState = State.Striking;
				return;
			}

		} else if (currentState == State.Striking) {
			if (!cueBall.rigidbody.IsSleeping()) {
				currentState = State.WaitingForCueBallToStop;
			}

		} else if (currentState == State.WaitingForCueBallToStop) {
			if (cueBall.rigidbody.IsSleeping()) {
				currentState = State.WaitingForStrike;
				cue.SendMessage("Reset");
				mainCamera.SendMessage("Reset");
			}
		}
	}
}