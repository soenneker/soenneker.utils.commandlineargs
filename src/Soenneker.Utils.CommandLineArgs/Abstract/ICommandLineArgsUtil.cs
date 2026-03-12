using System;
using System.Diagnostics.Contracts;

namespace Soenneker.Utils.CommandLineArgs.Abstract;

/// <summary>
/// Provides high-performance access to command-line arguments in a deterministic,
/// allocation-conscious manner.
/// </summary>
/// <remarks>
/// Implementations are expected to:
/// <list type="bullet">
/// <item>Exclude the executable path from the argument list.</item>
/// <item>Perform lookups using ordinal string comparison.</item>
/// <item>Avoid per-call allocations for common operations.</item>
/// </list>
/// This abstraction is suitable for dependency injection scenarios as well as
/// plain console applications.
/// </remarks>
public interface ICommandLineArgsUtil
{
    /// <summary>
    /// Gets the raw command-line arguments (excluding the executable path).
    /// </summary>
    /// <remarks>
    /// The returned array should not be modified by consumers.
    /// </remarks>
    string[] Args { get; }

    /// <summary>
    /// Returns a zero-allocation, read-only span view of the command-line arguments.
    /// </summary>
    /// <returns>
    /// A <see cref="ReadOnlySpan{T}"/> representing the underlying argument array.
    /// </returns>
    [Pure]
    ReadOnlySpan<string> AsSpan();

    /// <summary>
    /// Determines whether the specified key exists in the command-line arguments.
    /// </summary>
    /// <param name="key">
    /// The argument key to search for (for example, <c>--verbose</c> or <c>--mode</c>).
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the key is present; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// Supports both <c>--key value</c> and <c>--key=value</c> formats.
    /// </remarks>
    [Pure]
    bool Contains(string key);

    /// <summary>
    /// Attempts to retrieve the value associated with the specified key.
    /// </summary>
    /// <param name="key">
    /// The argument key to search for (for example, <c>--mode</c>).
    /// </param>
    /// <param name="value">
    /// When this method returns, contains the value associated with the key if found;
    /// otherwise, an empty string.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if a value was successfully found; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// Supports both <c>--key value</c> and <c>--key=value</c> formats.
    /// </remarks>
    [Pure]
    bool TryGet(string key, out string value);

    /// <summary>
    /// Attempts to retrieve a <see cref="bool"/> value associated with the specified key.
    /// </summary>
    /// <remarks>
    /// This method uses <see cref="bool.TryParse(string, out bool)"/> on the underlying string value.
    /// Presence-only flags (e.g., <c>--verbose</c>) should be checked via <see cref="Contains(string)"/>.
    /// </remarks>
    bool TryGetBool(string key, out bool value);

    /// <summary>
    /// Attempts to retrieve an <see cref="int"/> value associated with the specified key.
    /// </summary>
    /// <remarks>
    /// This method uses <see cref="int.TryParse(string, out int)"/> on the underlying string value.
    /// </remarks>
    bool TryGetInt(string key, out int value);
}
