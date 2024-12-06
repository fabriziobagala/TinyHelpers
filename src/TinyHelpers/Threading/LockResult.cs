namespace TinyHelpers.Threading;

/// <summary>
/// Represents the result of a lock operation.
/// </summary>
public enum LockResult
{
    /// <summary>
    /// The lock operation was successful.
    /// </summary>
    Success,

    /// <summary>
    /// The lock operation timed out.
    /// </summary>
    Timeout,

    /// <summary>
    /// The lock operation was canceled.
    /// </summary>
    Canceled,
    
    /// <summary>
    /// The lock operation had an invalid timeout.
    /// </summary>
    InvalidTimeout
}
