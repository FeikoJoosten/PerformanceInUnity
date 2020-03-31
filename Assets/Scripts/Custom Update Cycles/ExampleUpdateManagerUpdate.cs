using UnityEngine;

public class ExampleUpdateManagerUpdate : MonoBehaviour
{
	private int i;

	private void OnEnable() {
		UpdateManager.OnUpdateEvent += OnUpdateEvent;
	}

	private void OnDisable() {
		UpdateManager.OnUpdateEvent -= OnUpdateEvent;
	}
	
	public void OnUpdateEvent() {
		i++;
	}
}
