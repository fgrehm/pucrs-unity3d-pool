using UnityEngine;
using System.Collections;

public class CurrentPlayerController : MonoBehaviour {
	public GameObject cueBall;
	public GameObject cue;

	enum State {
		WaitingForStrike,
		Striking,
		WaitingForCueBallToStop
	}

	private State currentState = State.WaitingForStrike;

	void Update () {
		if (currentState == State.WaitingForStrike && Input.GetButton ("Fire1")) {
			cue.SendMessage("Strike");
			currentState = State.Striking;
		} else if (currentState == State.Striking) {
			if (!cueBall.rigidbody.IsSleeping ()) {
				currentState = State.WaitingForCueBallToStop;
			}
		} else if (currentState == State.WaitingForCueBallToStop) {
			if (cueBall.rigidbody.IsSleeping ()) {
				currentState = State.WaitingForStrike;
				cue.SendMessage("Reset");
			}
		}
	}
}
