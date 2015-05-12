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

	void Start () {
		cueBall.GetComponent<Rigidbody>().sleepThreshold = sleepThreshold;
		foreach (var ballRigidBody in redBalls.GetComponentsInChildren<Rigidbody>()) 
			ballRigidBody.sleepThreshold = sleepThreshold;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && ballsAreSleeping) {
			cue.SendMessage("Strike", new CueController.StrikeMessage(strikeSpeed, -multiplier, cueBall));
		}
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
