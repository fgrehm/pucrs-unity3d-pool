using UnityEngine;
using System;

namespace GameStates {
	public class StrikeState : AbstractGameObjectState {
		private PoolGameController gameController;
		
		private GameObject cue;
		private GameObject cueBall;

		private float speed = 30f;
		private float force = 0f;
		
		public StrikeState(MonoBehaviour parent) : base(parent) { 
			gameController = (PoolGameController)parent;
			cue = gameController.cue;
			cueBall = gameController.cueBall;

			var forceAmplitude = gameController.maxForce - gameController.minForce;
			var relativeDistance = (Vector3.Distance(cue.transform.position, cueBall.transform.position) - PoolGameController.MIN_DISTANCE) / (PoolGameController.MAX_DISTANCE - PoolGameController.MIN_DISTANCE);
			force = forceAmplitude * relativeDistance + gameController.minForce;
		}

		public override void FixedUpdate () {
			var distance = Vector3.Distance(cue.transform.position, cueBall.transform.position);
			if (distance < PoolGameController.MIN_DISTANCE) {
				cueBall.GetComponent<Rigidbody>().AddForce(gameController.strikeDirection * force);
				cue.GetComponent<Renderer>().enabled = false;
				cue.transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);
				gameController.currentState = new GameStates.WaitingForNextTurnState(gameController);
			} else {
				cue.transform.Translate(Vector3.down * speed * -1 * Time.fixedDeltaTime);
			}
		}
	}
}