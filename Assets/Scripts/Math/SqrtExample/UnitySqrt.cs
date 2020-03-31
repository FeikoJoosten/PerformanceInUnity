using System.Runtime.CompilerServices;
using Unity.Burst;
using UnityEngine;

public class UnitySqrt : Sqrt
{
	private delegate float UnityBurstSquareRootDelegate(int iterations);
	private UnityBurstSquareRootDelegate unityBurstSquareRootFunctionPointer;

	protected override void OnAwake() {
		unityBurstSquareRootFunctionPointer = BurstCompiler.CompileFunctionPointer<UnityBurstSquareRootDelegate>(UnityBurstSquareRoot).Invoke;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override void SqrtInternal(int iterations, bool useBurst, out float total) {
		if(useBurst) {
			total = unityBurstSquareRootFunctionPointer.Invoke(iterations);
		}else {
			total = 0;
			for(int i = 0; i < iterations; i++) {
				total += Mathf.Sqrt(i);
			}
        }
	}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [BurstCompile(FloatPrecision.High, FloatMode.Strict)]
    private static float UnityBurstSquareRoot(int iterations) {
		float total = 0;
		for(int i = 0; i < iterations; i++) {
			total += Mathf.Sqrt(i);
		}

		return total;
	}
}
