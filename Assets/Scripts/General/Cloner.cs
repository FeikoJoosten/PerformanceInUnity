using UnityEngine;

public class Cloner : MonoBehaviour
{
	public static event System.Action OnSpawningCompleted;

	[SerializeField] private int total = 10000;

	public GameObject objectToInstantiate = null;

	private void Awake ()  {
		if(objectToInstantiate) {
			InstantiatePrefab();
		} else {
			SpawnEmptyObjects();
		}

		OnSpawningCompleted?.Invoke();
		Destroy(this);
	}

	private void SpawnEmptyObjects() {
		for (int i = 0; i < total; i++) {
			new GameObject();
		}
	}

	private void InstantiatePrefab() {
		for (int i = 0; i < total; i++) {
			Instantiate(objectToInstantiate);
		}
	}
}