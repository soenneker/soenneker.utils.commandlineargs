using System;
using System.Runtime.CompilerServices;
using Soenneker.Extensions.String;
using Soenneker.Utils.CommandLineArgs.Abstract;

namespace Soenneker.Utils.CommandLineArgs;

/// <inheritdoc cref="ICommandLineArgsUtil"/>
public sealed class CommandLineArgsUtil : ICommandLineArgsUtil
{
    public string[] Args { get; }

    public ReadOnlySpan<string> AsSpan()
        => Args;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public CommandLineArgsUtil(string[]? args = null)
    {
        if (args is not null)
        {
            Args = args;
            return;
        }

        string[] raw = Environment.GetCommandLineArgs();

        if (raw.Length <= 1)
        {
            Args = [];
            return;
        }

        var trimmed = new string[raw.Length - 1];
        Array.Copy(raw, 1, trimmed, 0, trimmed.Length);
        Args = trimmed;
    }

    public bool Contains(string key)
    {
        if (key.IsNullOrEmpty())
            return false;

        string[] args = Args;

        for (int i = 0; i < args.Length; i++)
        {
            if (string.Equals(args[i], key, StringComparison.Ordinal))
                return true;

            if (StartsWithKeyAndEquals(args[i], key))
                return true;
        }

        return false;
    }

    public bool TryGet(string key, out string value)
    {
        value = string.Empty;

        if (key.IsNullOrEmpty())
            return false;

        string[] args = Args;

        for (int i = 0; i < args.Length; i++)
        {
            string current = args[i];

            if (StartsWithKeyAndEquals(current, key))
            {
                value = current[(key.Length + 1)..];
                return true;
            }

            if (string.Equals(current, key, StringComparison.Ordinal))
            {
                if (i + 1 < args.Length)
                {
                    value = args[i + 1];
                    return true;
                }

                return false;
            }
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool StartsWithKeyAndEquals(string arg, string key)
    {
        if (arg.Length <= key.Length + 1)
            return false;

        if (!arg.StartsWith(key, StringComparison.Ordinal))
            return false;

        return arg[key.Length] == '=';
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetBool(string key, out bool value)
    {
        value = false;

        if (!TryGet(key, out string s))
            return false;

        try
        {
            value = s.ToBool();
            return true;
        }
        catch
        {
            return false;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetInt(string key, out int value)
    {
        value = 0;

        if (!TryGet(key, out string s))
            return false;

        try
        {
            value = s.ToInt();
            return true;
        }
        catch
        {
            return false;
        }
    }
}