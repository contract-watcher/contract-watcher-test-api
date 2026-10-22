using System.Text.Json;
using ContractWatcher.Common.Contracts;
using ContractWatcher.SDK.Reporting.Interfaces;

namespace ContractWatcher.TestApi.Reporting;

public sealed class ConsoleReportPublisher : IReportPublisher
{
    public Task PublishAsync(ValidationReport report, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("===== CONTRACT WATCHER REPORT =====");
        Console.WriteLine(JsonSerializer.Serialize(report, new JsonSerializerOptions { WriteIndented = true }));
        Console.WriteLine("===================================");

        return Task.CompletedTask;
    }
}