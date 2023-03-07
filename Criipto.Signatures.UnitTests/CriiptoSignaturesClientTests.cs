using Xunit;

namespace Criipto.Signatures.UnitTests;

public class CriiptoSignaturesClientTests
{
    [Fact]
    public void IsDisposable()
    {
        var client = new CriiptoSignaturesClient("invalid", "invalid");

        client.Dispose();
    }
}