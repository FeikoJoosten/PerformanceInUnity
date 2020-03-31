using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public static event System.Action OnUpdateEvent;
    public static event System.Action OnLateUpdateEvent;
    public static event System.Action OnFixedUpdateEvent;

    private void Update() {
        OnUpdateEvent?.Invoke();
    }

    private void FixedUpdate() {
	OnFixedUpdateEvent?.Invoke();
    }

    private void LateUpdate() {
	OnLateUpdateEvent?.Invoke();
    }
}
