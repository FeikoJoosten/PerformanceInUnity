using UnityEngine;

public class SqrtTester : MonoBehaviour
{
	[SerializeField] private int iterations = 1000000;

	private void Awake() {
		UnitySqrt unitySqrt = new UnitySqrt();
		SystemSqrt systemSqrt = new SystemSqrt();

		Debug.Log($"{ nameof(UnitySqrt) }: { unitySqrt.SqrtTest(iterations) } VS { nameof(SystemSqrt) }: { systemSqrt.SqrtTest(iterations) }");
	}
}
