using System.Runtime.CompilerServices;
using Unity.Burst;

public class UnityMagnitude : Magnitude
{
    private delegate float UnityBurstMagnitudeDelegate(int iterations);
    private UnityBurstMagnitudeDelegate unityBurstMagnitudeFunctionPointer;

    protected override void OnAwake()
    {
        unityBurstMagnitudeFunctionPointer = BurstCompiler.CompileFunctionPointer<UnityBurstMagnitudeDelegate>(UnityBurstMagnitude).Invoke;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override void MagnitudeInternal(int iterations, bool useBurst, out float total)
    {
        if (useBurst)
        {
            total = unityBurstMagnitudeFunctionPointer.Invoke(iterations);
        }
        else
        {
            double result = 0;
            UnityEngine.Vector3 testVector = new UnityEngine.Vector3(1000, 1000, 1000);
            for (int i = 0; i < iterations; i++)
            {
                result += testVector.magnitude;
            }
            total = (float)result;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [BurstCompile(FloatPrecision.High, FloatMode.Strict)]
    private static float UnityBurstMagnitude(int iterations)
    {
        double result = 0;
        UnityEngine.Vector3 testVector = new UnityEngine.Vector3(1000, 1000, 1000);
        for (int i = 0; i < iterations; i++)
        {
            result += testVector.magnitude;
        }

        return (float)result;
    }
}