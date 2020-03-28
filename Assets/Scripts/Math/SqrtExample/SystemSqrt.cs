using System;

public class SystemSqrt : Sqrt
{
	protected override void SqrtInternal(int iterations) {
		for(int i = 0; i < iterations; i++) {
			Math.Sqrt(i);
		}
	}
}
