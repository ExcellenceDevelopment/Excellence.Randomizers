namespace Excellence.Randomizers.Providers;

/// <summary>
/// The random provider.
/// </summary>
public static class RandomProvider
{
    private static int _seed = Environment.TickCount;

    public static readonly ThreadLocal<Random> Random =
        new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref _seed)));
}