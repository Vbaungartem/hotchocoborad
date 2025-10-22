
namespace VB.HotChocoBoard.Domain.Abstraction.Results;

public interface ICustomResult
{
    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    bool IsSuccess { get; }
    
    bool IsFailure { get; }

    /// <summary>
    /// Gets the error information if the operation failed.
    /// </summary>
    Error? Error { get; }
    
    /// <summary>
    /// Gets the success data as a plain object.
    /// </summary>
    object? UntypedData { get; }
}