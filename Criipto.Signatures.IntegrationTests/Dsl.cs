using System.IO;
namespace Criipto.Signatures.IntegrationTests;

public class Dsl
{
    public static string CLIENT_ID = System.Environment.GetEnvironmentVariable("CRIIPTO_SIGNATURES_CLIENT_ID")!;
    public static string CLIENT_SECRET = System.Environment.GetEnvironmentVariable("CRIIPTO_SIGNATURES_CLIENT_SECRET")!;
    public static byte[] Sample = File.ReadAllBytes("./sample.pdf");
}