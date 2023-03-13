using System.IO;
using Xunit;
namespace Criipto.Signatures.IntegrationTests;

public class Dsl
{
    public static string CLIENT_ID = System.Environment.GetEnvironmentVariable("CRIIPTO_SIGNATURES_CLIENT_ID")!;
    public static string CLIENT_SECRET = System.Environment.GetEnvironmentVariable("CRIIPTO_SIGNATURES_CLIENT_SECRET")!;
    public static byte[] Sample = File.ReadAllBytes("./sample.pdf");
}

public class DslTests
{
    [Fact]
    public void ClientCredentialsSet()
    {
        Assert.NotNull(Dsl.CLIENT_ID);
        Assert.NotNull(Dsl.CLIENT_SECRET);
    }
}