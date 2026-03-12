using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Utils.CommandLineArgs.Abstract;

namespace Soenneker.Utils.CommandLineArgs.Registrars;

/// <summary>
/// DI-friendly access to command-line arguments for testable, deterministic applications.
/// </summary>
public static class CommandLineArgsUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ICommandLineArgsUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddCommandLineArgsUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<ICommandLineArgsUtil, CommandLineArgsUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ICommandLineArgsUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddCommandLineArgsUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<ICommandLineArgsUtil, CommandLineArgsUtil>();

        return services;
    }
}
