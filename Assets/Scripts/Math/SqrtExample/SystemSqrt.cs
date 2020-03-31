using System;
using System.Runtime.CompilerServices;
using Unity.Burst;

public class SystemSqrt : Sqrt
{
	private delegate float SystemBurstSquareRootDelegate(int iterations);
	private SystemBurstSquareRootDelegate systemBurstSquareRootFunctionPointer;

	protected override void OnAwake() {
		systemBurstSquareRootFunctionPointer = BurstCompiler.CompileFunctionPointer<SystemBurstSquareRootDelegate>(SystemBurstSquareRoot).Invoke;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override void SqrtInternal(int iterations, bool useBurst, out float total) {
		if(useBurst) {
			total = systemBurstSquareRootFunctionPointer.Invoke(iterations);
		}else {
			double result = 0;
			for(int i = 0; i < iterations; i++) {
				result += Math.Sqrt(i);
			}
			total = (float)result;
		}
	}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [BurstCompile(FloatPrecision.High, FloatMode.Strict)]
    private static float SystemBurstSquareRoot(int iterations) {
	    double total = 0;
		for(int i = 0; i < iterations; i++) {
			total += Math.Sqrt(i);
		}

		return (float)total;
    }
}
