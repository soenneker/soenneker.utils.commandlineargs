[![](https://img.shields.io/nuget/v/soenneker.utils.commandlineargs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.commandlineargs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.commandlineargs/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.commandlineargs/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.commandlineargs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.commandlineargs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.commandlineargs/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.commandlineargs/actions/workflows/codeql.yml)

# Soenneker.Utils.CommandLineArgs

DI-friendly, allocation-conscious lookup of command-line arguments.

## Installation

```bash
dotnet add package Soenneker.Utils.CommandLineArgs
```

## Registration

```csharp
using Soenneker.Utils.CommandLineArgs.Registrars;

services.AddCommandLineArgsUtilAsSingleton();
```

The singleton captures the process arguments when it is first resolved. `AddCommandLineArgsUtilAsScoped()` is also available when each scope should construct its own snapshot.

For deterministic tests or direct use, supply the argument array explicitly:

```csharp
var args = new CommandLineArgsUtil(
    ["--environment=staging", "--workers", "4", "--verbose"]);

args.TryGet("--environment", out string environment); // staging
args.TryGetInt("--workers", out int workers);          // 4
bool verbose = args.Contains("--verbose");             // true
```

## Supported forms

`Contains()` and `TryGet()` use ordinal, case-sensitive matching and recognize both forms:

```text
--key=value
--key value
```

Presence-only flags should be checked with `Contains()`. `TryGetBool()` requires an explicit value such as `--enabled=true`.

The parser is deliberately simple: for the separated form, the item immediately after the key is returned as its value, even if that item resembles another option. It does not handle short-option grouping, quoting, duplicate resolution beyond the first match, or command-line schema validation.

`AsSpan()` exposes a read-only view without allocating. `Args` exposes the underlying array for compatibility; consumers should treat it as immutable because changing it changes subsequent lookups.
