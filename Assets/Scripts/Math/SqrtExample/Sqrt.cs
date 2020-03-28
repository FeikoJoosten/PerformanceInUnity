using System.Diagnostics;

public abstract class Sqrt
{
	public float SqrtTest(int iterations) {
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();

		SqrtInternal(iterations);

		stopwatch.Stop();

		return stopwatch.ElapsedMilliseconds;
	}

	protected abstract void SqrtInternal(int iterations);
}
