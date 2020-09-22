using UnityEngine;

public class MagnitudeTester : MonoBehaviour
{
    [SerializeField] private int iterations = 1000000;

    private readonly SystemMagnitude systemMagnitude = new SystemMagnitude();
    private readonly UnityMagnitude unityMagnitude = new UnityMagnitude();
    private readonly MathematicsMagnitude mathematicsMagnitude = new MathematicsMagnitude();

    private void Awake()
    {
        systemMagnitude.Awake();
        unityMagnitude.Awake();
        mathematicsMagnitude.Awake();

        Debug.Log($"{ nameof(UnityMagnitude) }: { unityMagnitude.MagnitudeTest(iterations, false, out float unityMagnitudeTotal) } Total: { unityMagnitudeTotal }" +
                  $" VS Burst { nameof(UnityMagnitude) }: { unityMagnitude.MagnitudeTest(iterations, true, out float unityBurstMagnitudeTotal) } Total: { unityBurstMagnitudeTotal }" +
                  $" VS { nameof(SystemMagnitude) }: { systemMagnitude.MagnitudeTest(iterations, false, out float systemMagnitudeTotal) } Total: { systemMagnitudeTotal }" +
                  $" VS Burst { nameof(SystemMagnitude) }: { systemMagnitude.MagnitudeTest(iterations, true, out float systemBurstMagnitudeTotal) } Total: { systemBurstMagnitudeTotal }" +
                  $" VS { nameof(MathematicsMagnitude) }: { mathematicsMagnitude.MagnitudeTest(iterations, false, out float mathematicsMagnitudeTotal) } Total: { mathematicsMagnitudeTotal }" +
                  $" VS Burst { nameof(MathematicsMagnitude) }: { mathematicsMagnitude.MagnitudeTest(iterations, true, out float mathematicsBurstMagnitudeTotal) } Total: { mathematicsBurstMagnitudeTotal }");
    }
}