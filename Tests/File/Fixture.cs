using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tests.File;

public class Fixture(IMessageSink s) : TestFixture<Program>(s)
{
    public List<string> FileNames { get; set; } = new();

    protected override Task SetupAsync()
    {
        Client = CreateClient(
            c =>
            {
                // c.DefaultRequestHeaders.Authorization = new("Bearer", bearerToken);
            });

        return Task.CompletedTask;
    }

    protected override Task TearDownAsync()
    {
        Client.Dispose();

        return Task.CompletedTask;
    }
}