using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Mathematics;

public class MathematicsSqrt : Sqrt
{
	private delegate float MathematicsBurstSquareRootDelegate(int iterations);
	private MathematicsBurstSquareRootDelegate mathematicsBurstSquareRootFunctionPointer;

	protected override void OnAwake() {
		mathematicsBurstSquareRootFunctionPointer = BurstCompiler.CompileFunctionPointer<MathematicsBurstSquareRootDelegate>(MathematicsBurstSquareRoot).Invoke;
    }
	
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
    protected override void SqrtInternal(int iterations, bool useBurst, out float total) {
		if(useBurst) {
			total = mathematicsBurstSquareRootFunctionPointer.Invoke(iterations);
		} else {
			total = 0;
			for(int i = 0; i < iterations; i++) {
				total += math.sqrt(i);
			}
        }
	}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [BurstCompile(FloatPrecision.Standard, FloatMode.Fast)]
    private static float MathematicsBurstSquareRoot(int iterations) {
		float total = 0;
		for(int i = 0; i < iterations; i++) {
			total += math.sqrt(i);
		}

		return total;
	}
}
