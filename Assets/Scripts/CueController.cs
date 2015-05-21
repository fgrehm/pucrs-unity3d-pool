using UnityEngine;
using System.Collections;

public class CueController : MonoBehaviour {
	public GameObject cueBall;

	private float cueDirection = 1;
	private float speed = 7;

	void FixedUpdate () {
		var distance = Vector3.Distance(transform.position, cueBall.transform.position);
		if (distance < 27.5 || distance > 36)
			cueDirection *= -1;
		transform.Translate(Vector3.down * speed * cueDirection * Time.fixedDeltaTime);
	}
}
