[![](https://img.shields.io/nuget/v/soenneker.utils.commandlineargs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.commandlineargs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.commandlineargs/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.commandlineargs/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.commandlineargs.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.commandlineargs/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.commandlineargs/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.commandlineargs/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.CommandLineArgs
DI-friendly access to command-line arguments for testable, deterministic applications.

## Installation

```bash
dotnet add package Soenneker.Utils.CommandLineArgs
```

## Quick start

```csharp
using Soenneker.Utils.CommandLineArgs.Registrars;

services.AddCommandLineArgsUtilAsSingleton();
```

Then inject `ICommandLineArgsUtil` wherever you need it.

## Common operations

- `AsSpan()` - Returns a zero-allocation, read-only span view of the command-line arguments.
- `Contains()` - Determines whether the specified key exists in the command-line arguments.
- `TryGet()` - Attempts to retrieve the value associated with the specified key.
- `TryGetBool()` - Attempts to retrieve a `bool` value associated with the specified key.
- `TryGetInt()` - Attempts to retrieve an `int` value associated with the specified key.
