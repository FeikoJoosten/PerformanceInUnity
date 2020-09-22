using System.Diagnostics;

public abstract class Magnitude
{
    private readonly Stopwatch stopwatch;

    protected Magnitude()
    {
        stopwatch = new Stopwatch();
    }

    public void Awake()
    {
        OnAwake();
    }

    public float MagnitudeTest(int iterations, bool useBurst, out float total)
    {
        stopwatch.Reset();
        stopwatch.Start();

        MagnitudeInternal(iterations, useBurst, out total);

        stopwatch.Stop();

        return stopwatch.ElapsedTicks;
    }

    protected abstract void OnAwake();
    protected abstract void MagnitudeInternal(int iterations, bool useBurst, out float total);
}