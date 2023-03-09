using Xunit;

namespace Criipto.Signatures.UnitTests;

public class CriiptoSignaturesClientTests
{
    [Fact]
    public void IsDisposable()
    {
        using (var client = new CriiptoSignaturesClient("invalid", "invalid")) {
            
        }
    }
}