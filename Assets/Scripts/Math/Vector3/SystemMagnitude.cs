using System;
using System.Runtime.CompilerServices;
using Unity.Burst;

public class SystemMagnitude : Magnitude
{
    private delegate float SystemBurstMagnitudeDelegate(int iterations);
    private SystemBurstMagnitudeDelegate systemBurstMagnitudeFunctionPointer;

    protected override void OnAwake()
    {
        systemBurstMagnitudeFunctionPointer = BurstCompiler.CompileFunctionPointer<SystemBurstMagnitudeDelegate>(SystemBurstMagnitude).Invoke;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override void MagnitudeInternal(int iterations, bool useBurst, out float total)
    {
        if (useBurst)
        {
            total = systemBurstMagnitudeFunctionPointer.Invoke(iterations);
        }
        else
        {
            double result = 0;
            UnityEngine.Vector3 testVector = new UnityEngine.Vector3(1000, 1000, 1000);
            for (int i = 0; i < iterations; i++)
            {
                result += Math.Sqrt(testVector.x * testVector.x + testVector.y * testVector.y + testVector.z * testVector.z);
            }
            total = (float)result;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [BurstCompile(FloatPrecision.High, FloatMode.Strict)]
    private static float SystemBurstMagnitude(int iterations)
    {
        double result = 0;
        UnityEngine.Vector3 testVector = new UnityEngine.Vector3(1000, 1000, 1000);
        for (int i = 0; i < iterations; i++)
        {
            result += Math.Sqrt(testVector.x * testVector.x + testVector.y * testVector.y + testVector.z * testVector.z);
        }

        return (float)result;
    }
}