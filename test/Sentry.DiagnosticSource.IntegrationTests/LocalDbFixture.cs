using System.Runtime.InteropServices;
using DiffEngine;

namespace Sentry.DiagnosticSource.IntegrationTests;

public sealed class LocalDbFixture : IDisposable
{
    public SqlInstance SqlInstance { get; }

    public LocalDbFixture()
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return;
        }

        SqlInstance = new SqlInstance(
            name: "SqlListenerTests" + Namer.RuntimeAndVersion,
            buildTemplate: TestDbBuilder.CreateTable);
    }

    public void Dispose()
    {
        if (BuildServerDetector.Detected)
        {
            SqlInstance?.Cleanup();
        }
    }
}
