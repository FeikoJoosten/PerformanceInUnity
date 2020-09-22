using System.Runtime.CompilerServices;
using Unity.Burst;

public class MathematicsMagnitude : Magnitude
{
    private delegate float MathematicsBurstMagnitudeDelegate(int iterations);
    private MathematicsBurstMagnitudeDelegate mathematicsBurstMagnitudeFunctionPointer;

    protected override void OnAwake()
    {
        mathematicsBurstMagnitudeFunctionPointer = BurstCompiler.CompileFunctionPointer<MathematicsBurstMagnitudeDelegate>(MathematicsBurstMagnitude).Invoke;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override void MagnitudeInternal(int iterations, bool useBurst, out float total)
    {
        if (useBurst)
        {
            total = mathematicsBurstMagnitudeFunctionPointer.Invoke(iterations);
        }
        else
        {
            double result = 0;
            Unity.Mathematics.float3 testVector = new Unity.Mathematics.float3(1000, 1000, 1000);
            for (int i = 0; i < iterations; i++)
            {
                result += Unity.Mathematics.math.length(testVector);
            }
            total = (float)result;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [BurstCompile(FloatPrecision.High, FloatMode.Strict)]
    private static float MathematicsBurstMagnitude(int iterations)
    {
        double result = 0;
        Unity.Mathematics.float3 testVector = new Unity.Mathematics.float3(1000, 1000, 1000);
        for (int i = 0; i < iterations; i++)
        {
            result += Unity.Mathematics.math.length(testVector);
        }

        return (float)result;
    }
}