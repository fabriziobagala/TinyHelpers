namespace TinyHelpers.Threading;

/// <summary>
/// Provides a lock that can be used asynchronously.
/// </summary>
public class AsyncLock : IDisposable
{
    private readonly SemaphoreSlim semaphoreSlim = new(1, 1);
    private bool disposed = false;

    /// <summary>
    /// Asynchronously waits for the lock to become available.
    /// </summary>
    /// <param name="cancellationToken">A token that can be used to request cancellation of the asynchronous operation.</param>
    /// <returns>A task that returns an <see cref="AsyncLockResult"/>.</returns>
    public async Task<AsyncLockResult> LockAsync(CancellationToken cancellationToken = default)
    {
        var acquired = await semaphoreSlim.WaitAsync(0, cancellationToken).ConfigureAwait(false);
        if (acquired)
        {
            return AsyncLockResult.Success(this);
        }
        
        return cancellationToken.IsCancellationRequested 
            ? AsyncLockResult.Canceled() 
            : AsyncLockResult.Timeout();
    }

    /// <summary>
    /// Asynchronously waits for the lock to become available with a specified timeout.
    /// </summary>
    /// <param name="timeout">The amount of time to wait before the task is canceled.</param>
    /// <param name="cancellationToken">A token that can be used to request cancellation of the asynchronous operation.</param>
    /// <returns>A task that returns an <see cref="AsyncLockResult"/>.</returns>
    public async Task<AsyncLockResult> LockAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        var acquired = await semaphoreSlim.WaitAsync(timeout, cancellationToken).ConfigureAwait(false);
        if (acquired)
        {
            return AsyncLockResult.Success(this);
        }
        
        return cancellationToken.IsCancellationRequested 
            ? AsyncLockResult.Canceled() 
            : AsyncLockResult.Timeout();
    }

    /// <summary>
    /// Asynchronously waits for the lock to become available with a specified timeout in milliseconds.
    /// </summary>
    /// <param name="millisecondsTimeout">The number of milliseconds to wait.</param>
    /// <param name="cancellationToken">A token that can be used to request cancellation of the asynchronous operation.</param>
    /// <returns>A task that returns an <see cref="AsyncLockResult"/>.</returns>
    public async Task<AsyncLockResult> LockAsync(int millisecondsTimeout, CancellationToken cancellationToken = default)
    {
        var acquired = await semaphoreSlim.WaitAsync(millisecondsTimeout, cancellationToken).ConfigureAwait(false);
        if (acquired)
        {
            return AsyncLockResult.Success(this);
        }
        
        return cancellationToken.IsCancellationRequested 
            ? AsyncLockResult.Canceled() 
            : AsyncLockResult.Timeout();
    }

    /// <summary>
    /// Releases all resources used by the current instance of the <see cref="AsyncLock"/> class.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="AsyncLock"/> and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing"><see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                // Dispose managed resources
                if (semaphoreSlim.CurrentCount == 0)
                {
                    semaphoreSlim.Release();
                }

                semaphoreSlim.Dispose();
            }

            // Free unmanaged resources (if any)
            disposed = true;
        }
    }

    /// <summary>
    /// Finalizes an instance of the <see cref="AsyncLock"/> class.
    /// </summary>
    ~AsyncLock()
    {
        Dispose(false);
    }
}
