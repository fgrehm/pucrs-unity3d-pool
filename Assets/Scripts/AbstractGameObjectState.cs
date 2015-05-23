using UnityEngine;

public abstract class AbstractGameObjectState : IGameObjectState {
	protected MonoBehaviour parent;
	public AbstractGameObjectState(MonoBehaviour parent) {
		this.parent = parent;
	}

	public virtual void Update() { }
	public virtual void FixedUpdate() { }
	public virtual void LateUpdate() { }
}