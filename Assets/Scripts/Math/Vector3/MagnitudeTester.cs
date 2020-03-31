using System.Runtime.CompilerServices;
using Unity.Burst;
using UnityEngine;
using Unity.Mathematics;

public class MagnitudeTester : MonoBehaviour
{
	private delegate float BurstUnityMagnitudeDelegate(int iterations);
	private delegate float BurstFastMagnitudeDelegate(int iterations);
    private delegate float BurstFloat3MagnitudeDelegate(int iterations);

    private void Awake() {
		System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
		BurstUnityMagnitudeDelegate burstUnityMagnitudeFunctionPointer = BurstCompiler.CompileFunctionPointer<BurstUnityMagnitudeDelegate>(CalculateUnityMagnitude).Invoke;
		BurstFastMagnitudeDelegate burstFastMagnitudeFunctionPointer = BurstCompiler.CompileFunctionPointer<BurstFastMagnitudeDelegate>(CalculateFastMagnitude).Invoke;
        BurstFloat3MagnitudeDelegate burstFloat3MagnitudeFunctionPointer = BurstCompiler.CompileFunctionPointer<BurstFloat3MagnitudeDelegate>(CalculateMathematicsMagnitude).Invoke;

        Vector3 testVector = new Vector3(1000, 1000, 1000);
        float3 mathematicsVector = new float3(1000, 1000, 1000);

        const int iterations = 1000000;
		float unityMagnitude = 0;
		float burstUnityMagnitude = 0;
		float fastMagnitude = 0;
		float burstFastMagnitude = 0;
		float mathematicsMagnitude = 0;
		float burstMathematicsMagnitude = 0;

        stopwatch.Start();
        for(int i = 0; i < iterations; i++) {
	        unityMagnitude += testVector.magnitude;
        }
        stopwatch.Stop();
		float unitySpeed = stopwatch.ElapsedTicks;

		stopwatch.Reset();
		stopwatch.Start();
		burstUnityMagnitude = burstUnityMagnitudeFunctionPointer.Invoke(iterations);
		stopwatch.Stop();
		float burstUnitySpeed = stopwatch.ElapsedTicks;

        stopwatch.Reset();
		stopwatch.Start();
		for (int i = 0; i < iterations; i++) {
			fastMagnitude += (float)System.Math.Sqrt(testVector.x * testVector.x + testVector.y * testVector.y + testVector.z * testVector.z);
		}
        stopwatch.Stop();
		float fastSpeed = stopwatch.ElapsedTicks;

		stopwatch.Reset();
		stopwatch.Start();
		burstFastMagnitude = burstFastMagnitudeFunctionPointer.Invoke(iterations);
		stopwatch.Stop();
		float burstFastSpeed = stopwatch.ElapsedTicks;

        stopwatch.Reset();
		stopwatch.Start();
		for(int i = 0; i < iterations; i++) {
			mathematicsMagnitude += math.length(mathematicsVector);
		}
        stopwatch.Stop();
		float mathematicsSpeed = stopwatch.ElapsedTicks;

		stopwatch.Reset();
		stopwatch.Start();
		burstMathematicsMagnitude = burstFloat3MagnitudeFunctionPointer.Invoke(iterations);
		stopwatch.Stop();
		float burstMathematicsSpeed = stopwatch.ElapsedTicks;

        Debug.Log($"Unity Magnitude: Elapsed Ticks { unitySpeed } Result { unityMagnitude / iterations }" +
                  $" VS Unity Burst Magnitude: Elapsed Ticks { burstUnitySpeed } Result { burstUnityMagnitude / iterations }" +
                  $" VS Fast Magnitude: Elapsed Ticks { fastSpeed } Result { fastMagnitude / iterations }" +
                  $" VS Fast Burst Magnitude: Elapsed Ticks { burstFastSpeed } Result { burstFastMagnitude / iterations }" +
                  $" VS Unity Mathematics Magnitude: Elapsed Ticks { mathematicsSpeed } Result { mathematicsMagnitude / iterations }" +
                  $" VS Unity Burst Mathematics Magnitude: Elapsed Ticks { burstMathematicsSpeed } Result { burstMathematicsMagnitude / iterations }");
    }

    [BurstCompile(FloatPrecision.High, FloatMode.Strict)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static float CalculateUnityMagnitude(int iterations) {
	    Vector3 testVector = new Vector3(1000, 1000, 1000);
        float output = 0;
	    for(int i = 0; i < iterations; i++) {
		    output += testVector.magnitude;
	    }

	    return output;
    }

    [BurstCompile(FloatPrecision.High, FloatMode.Strict)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static float CalculateFastMagnitude(int iterations) {
	    Vector3 testVector = new Vector3(1000, 1000, 1000);
        float output = 0;
	    for(int i = 0; i < iterations; i++) {
		    output += (float)System.Math.Sqrt(testVector.x * testVector.x + testVector.y * testVector.y + testVector.z * testVector.z);
	    }

	    return output;
    }

    [BurstCompile(FloatPrecision.High, FloatMode.Strict)]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static float CalculateMathematicsMagnitude(int iterations) {
		float3 mathematicsVector = new float3(1000, 1000, 1000);
		float output = 0;
        for(int i = 0; i < iterations; i++) {
			output += math.length(mathematicsVector);
		}

        return output;
	}
}
