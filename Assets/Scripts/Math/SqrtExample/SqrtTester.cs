using UnityEngine;

public class SqrtTester : MonoBehaviour
{
	[SerializeField] private int iterations = 1000000;

	private readonly SystemSqrt systemSqrt = new SystemSqrt();
	private readonly UnitySqrt unitySqrt = new UnitySqrt();
	private readonly MathematicsSqrt mathematicsSqrt = new MathematicsSqrt();

    private void Awake() {
		systemSqrt.Awake();
		unitySqrt.Awake();
		mathematicsSqrt.Awake();

		Debug.Log($"{ nameof(UnitySqrt) }: { unitySqrt.SqrtTest(iterations, false, out float unitySqrtTotal) } Total: { unitySqrtTotal }" +
		          $" VS Burst { nameof(UnitySqrt) }: { unitySqrt.SqrtTest(iterations, true, out float unityBurstSqrtTotal) } Total: { unityBurstSqrtTotal }" +
		          $" VS { nameof(SystemSqrt) }: { systemSqrt.SqrtTest(iterations, false, out float systemSqrtTotal) } Total: { systemSqrtTotal }" +
		          $" VS Burst { nameof(SystemSqrt) }: { systemSqrt.SqrtTest(iterations, true, out float systemBurstSqrtTotal) } Total: { systemBurstSqrtTotal }" +
                  $" VS { nameof(MathematicsSqrt) }: { mathematicsSqrt.SqrtTest(iterations, false, out float mathematicsSqrtTotal) } Total: { mathematicsSqrtTotal }" +
		          $" VS Burst { nameof(MathematicsSqrt) }: { mathematicsSqrt.SqrtTest(iterations, true, out float mathematicsBurstSqrtTotal) } Total: { mathematicsBurstSqrtTotal }");
	}
}
