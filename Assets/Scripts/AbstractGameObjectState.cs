using UnityEngine;

public abstract class AbstractGameObjectState : IGameObjectState {
	protected MonoBehaviour parent;
	public AbstractGameObjectState(MonoBehaviour parent) {
		this.parent = parent;
	}

	public void Update() { }
	public void FixedUpdate() { }
	public void LateUpdate() { }
}