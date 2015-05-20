using UnityEngine;
using System.Collections;

public class CurrentPlayerController : MonoBehaviour {
	public GameObject cue;
	public GameObject cueBall;
	public GameObject redBalls;
	public float sleepThreshold;

	// TODO: This is going to be handled by the script instead of being passed in
	public float strikeSpeed;
	public float multiplier;
	private State currentState;

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
		if (!Input.GetButton ("Fire1") || !ballsAreSleeping)
			return;

		cue.SendMessage("Strike", new CueController.StrikeMessage(strikeSpeed, -multiplier, cueBall));
		currentState = State.Striking;
	}

	private void HandleStrikingUpdate() {
		if (cueBall.GetComponent<Rigidbody>().velocity != Vector3.zero)
			currentState = State.WaitingForTurnToEnd;
	}

	private void HandleWaitingForTurnToEndUpdate() {
		if (!ballsAreSleeping)
			return;

		currentState = State.WaitingForStrike;
		cue.SendMessage("Reset", cueBall);
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
