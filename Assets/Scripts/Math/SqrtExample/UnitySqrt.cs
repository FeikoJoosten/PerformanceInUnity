using UnityEngine;

public class UnitySqrt : Sqrt
{
	protected override void SqrtInternal(int iterations) {
		for(int i = 0; i < iterations; i++) {
			Mathf.Sqrt(i);
		}
    }
}
