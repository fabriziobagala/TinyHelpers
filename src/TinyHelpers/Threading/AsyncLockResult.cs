namespace TinyHelpers.Threading;

/// <summary>
/// Represents the result of an asynchronous lock operation.
/// </summary>
public readonly struct AsyncLockResult
{
    /// <summary>
    /// Gets the asynchronous lock.
    /// </summary>
    public AsyncLock? Lock { get; }
    
    /// <summary>
    /// Gets the result of the lock operation.
    /// </summary>
    public LockResult Result { get; }

    private AsyncLockResult(AsyncLock? @lock, LockResult result)
    {
        Lock = @lock;
        Result = result;
    }

    internal static AsyncLockResult Success(AsyncLock @lock) => new(@lock, LockResult.Success);
    internal static AsyncLockResult Timeout() => new(null, LockResult.Timeout);
    internal static AsyncLockResult Canceled() => new(null, LockResult.Canceled);
    internal static AsyncLockResult InvalidTimeout() => new(null, LockResult.InvalidTimeout);
}
