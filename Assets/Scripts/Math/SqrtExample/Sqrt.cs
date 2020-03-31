using System.Diagnostics;

public abstract class Sqrt
{
	private readonly Stopwatch stopwatch;

	protected Sqrt() {
		stopwatch = new Stopwatch();
	}

	public void Awake() {
		OnAwake();
	}

    public float SqrtTest(int iterations, bool useBurst, out float total) {
		stopwatch.Reset();
		stopwatch.Start();

		SqrtInternal(iterations, useBurst, out total);

		stopwatch.Stop();

		return stopwatch.ElapsedTicks;
	}

    protected abstract void OnAwake();
	protected abstract void SqrtInternal(int iterations, bool useBurst, out float total);
}
