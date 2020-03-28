using UnityEngine;

public class MagnitudeTester : MonoBehaviour
{
	private void Awake() {
		System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
		
		Vector3 testVector = new Vector3(1000, 1000, 1000);
		const int iterations = 1000000;
		float unityMagnitude = 0;
		float fastMagnitude = 0;

        stopwatch.Start();
        for (int i = 0; i < iterations; i++) {
	        unityMagnitude += testVector.magnitude;
        }
		stopwatch.Stop();
		float unitySpeed = stopwatch.ElapsedMilliseconds;

		stopwatch.Reset();
		stopwatch.Start();
		for(int i = 0; i < iterations; i++) {
			fastMagnitude += (float) System.Math.Sqrt(testVector.x * testVector.x + testVector.y * testVector.y + testVector.z * testVector.z);
		}
		stopwatch.Stop();
		float fastSpeed = stopwatch.ElapsedMilliseconds;

		Debug.Log($"Unity Magnitude: Elapsed Milliseconds { unitySpeed } Result { unityMagnitude / iterations } VS Fast Magnitude: Elapsed Milliseconds { fastSpeed } Result { fastMagnitude / iterations }");
	}
}
