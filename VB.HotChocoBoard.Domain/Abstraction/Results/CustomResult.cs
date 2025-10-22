using System.Text.Json.Serialization;

namespace VB.HotChocoBoard.Domain.Abstraction.Results;

public sealed class CustomResult<TResultData> : ICustomResult
{
    /// <summary>
    /// Gets the data returned by the operation if successful; otherwise, null.
    /// </summary>
    public TResultData? Data { get; private init; }

    /// <summary>
    /// Gets the error information if the operation failed; otherwise, null.
    /// </summary>
    public Error? Error { get; private init; }

    public object? UntypedData => Data;

    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public bool IsSuccess => Error is null;

    /// <summary>
    /// Gets a value indicating whether the operation failed.
    /// </summary>
    [JsonIgnore]
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Creates a successful result containing the specified data.
    /// </summary>
    /// <param name="data">The data returned by the operation.</param>
    /// <returns>A successful <see cref="CustomResult{TResultData}"/> instance.</returns>
    public static CustomResult<TResultData> Success(TResultData data)
    {
        return new CustomResult<TResultData>
        {
            Data = data
        };
    }

    /// <summary>
    /// Creates a failed result containing the specified error.
    /// </summary>
    /// <param name="error">The error information.</param>
    /// <returns>A failed <see cref="CustomResult{TResultData}"/> instance.</returns>
    public static CustomResult<TResultData> Failure(Error error)
    {
        return new CustomResult<TResultData>
        {
            Error = error
        };
    }
}