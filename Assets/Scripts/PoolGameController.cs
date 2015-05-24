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

	public IGameObjectState currentState;

	// Use this for initialization
	void Start() {
		strikeDirection = Vector3.forward;

		currentState = new GameStates.WaitingForStrikeState(this);
	}
	
	// Update is called once per frame
	void Update() {
		var body = cueBall.GetComponent<Rigidbody>();

		if (Input.GetButton("Fire1") && body.IsSleeping()) {
			body.AddForce(strikeDirection * maxForce);
			cue.GetComponent<Renderer>().enabled = false;
			currentState = new GameStates.WaitingForNextTurnState(this);
		} else if (Input.GetButton("Fire2") && body.IsSleeping()) {
			body.AddForce(strikeDirection * minForce);
			cue.GetComponent<Renderer>().enabled = false;
			currentState = new GameStates.WaitingForNextTurnState(this);
		}

		currentState.Update();
	}

	void FixedUpdate() {
		currentState.FixedUpdate();
	}

	void LateUpdate() {
		currentState.LateUpdate();
	}
}
