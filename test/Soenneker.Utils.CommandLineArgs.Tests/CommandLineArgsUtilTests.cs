using Soenneker.Utils.CommandLineArgs.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Utils.CommandLineArgs.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CommandLineArgsUtilTests : HostedUnitTest
{
    private readonly ICommandLineArgsUtil _util;

    public CommandLineArgsUtilTests(Host host) : base(host)
    {
        _util = Resolve<ICommandLineArgsUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
