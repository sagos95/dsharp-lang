namespace DSharp.Sandbox.Generated;

// Helper class for D# - allows running async methods without awaiting them
public static class Run
{
    /// <summary>
    /// Runs an async method without awaiting it (fire-and-forget pattern)
    /// </summary>
    public static void Async(Func<Task> action)
    {
        _ = action();
    }
    
    /// <summary>
    /// Runs an async method without awaiting it (fire-and-forget pattern)
    /// </summary>
    public static void Async<T>(Func<Task<T>> action)
    {
        _ = action();
    }
}

