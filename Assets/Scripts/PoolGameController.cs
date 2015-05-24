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

	public const float MIN_DISTANCE = 27.5f;
	public const float MAX_DISTANCE = 32f;
	
	public IGameObjectState currentState;

	// Use this for initialization
	void Start() {
		strikeDirection = Vector3.forward;

		currentState = new GameStates.WaitingForStrikeState(this);
	}
	
	// Update is called once per frame
	void Update() {
		currentState.Update();
	}

	void FixedUpdate() {
		currentState.FixedUpdate();
	}

	void LateUpdate() {
		Debug.Log(currentState);
		currentState.LateUpdate();
	}
}
