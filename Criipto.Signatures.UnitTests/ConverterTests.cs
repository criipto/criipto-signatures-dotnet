using Xunit;
using Newtonsoft.Json;
using Criipto.Signatures.Models;

namespace Criipto.Signatures.UnitTests;

public class ConverterTests
{
    [Fact]
    public void SignatoryDocumentEdgeIsTolerant()
    {
        var json = """
{
    "status": "SIGNED_IN_THE_FUTURE"
}
""".Trim();

        var actual = JsonConvert.DeserializeObject<SignatoryDocumentEdge>(json);

        Assert.NotNull(actual);
        Assert.Equal(SignatoryDocumentStatus.FUTURE_ADDED_VALUE, actual!.status);
    }

    [Fact]
    public void SignatoryDocumentEdgeIsCorrect()
    {
        var json = """
{
    "status": "SIGNED"
}
""".Trim();

        var actual = JsonConvert.DeserializeObject<SignatoryDocumentEdge>(json);

        Assert.NotNull(actual);
        Assert.Equal(SignatoryDocumentStatus.SIGNED, actual!.status);
    }

    [Fact]
    public void SignatureOrderStatusIsTolerant()
    {
        var json = """
{
    "status": null
}
""".Trim();

        var actual = JsonConvert.DeserializeObject<SignatureOrder>(json);

        Assert.NotNull(actual);
        Assert.Equal(SignatureOrderStatus.FUTURE_ADDED_VALUE, actual!.status);
    }
}