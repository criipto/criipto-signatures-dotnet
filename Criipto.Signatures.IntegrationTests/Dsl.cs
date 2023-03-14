using System.IO;
using Xunit;
using Microsoft.Extensions.Configuration;
namespace Criipto.Signatures.IntegrationTests;


public class Dsl
{
    public static byte[] Sample = File.ReadAllBytes("./sample.pdf");

    public static IConfiguration InitConfiguration()
    {
        var config =
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json", true)
                .AddEnvironmentVariables()
                .Build();
        return config;
    }

    public static IConfiguration Configuration = InitConfiguration();
    public static string CLIENT_ID { get => Configuration["CRIIPTO_SIGNATURES_CLIENT_ID"]!; }
    public static string CLIENT_SECRET { get => Configuration["CRIIPTO_SIGNATURES_CLIENT_SECRET"]!; }
}

public class DslTests
{
    [Fact]
    public void ClientCredentialsSet()
    {
        Assert.NotNull(Dsl.Configuration["CRIIPTO_SIGNATURES_CLIENT_ID"]);
        Assert.NotNull(Dsl.Configuration["CRIIPTO_SIGNATURES_CLIENT_SECRET"]);
    }
}