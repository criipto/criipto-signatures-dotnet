using Xunit;
using Criipto.Signatures;
using System.Collections.Generic;
using System.IO;
namespace Criipto.Signatures.IntegrationTests;

public class QuerySignatureOrderTests
{

    [Fact]
    public async void QueryReturnsSignatureOrder()
    {
        using (var client = new CriiptoSignaturesClient(Dsl.CLIENT_ID, Dsl.CLIENT_SECRET, "test"))
        {
            // Arrange
            var signatureOrder = await client.CreateSignatureOrder(
                new Types.CreateSignatureOrderInput()
                {
                    title = "Title",
                    expiresInDays = 1,
                    documents = new List<Types.DocumentInput>(){
                        new Types.DocumentInput {
                            pdf =
                                new Types.PadesDocumentInput
                                {
                                    title = "TEST",
                                    blob = Dsl.Sample
                                }
                        }
                    }
                }
            );

            // Act
            var actual = await client.QuerySignatureOrder(
                signatureOrder.id
            );

            // Assert
            Assert.NotNull(actual?.id);
            Assert.Equal(signatureOrder.id, actual!.id);
        }
    }

    [Fact]
    public async void QueryReturnsNullForUnknownSignatureOrder()
    {
        using (var client = new CriiptoSignaturesClient(Dsl.CLIENT_ID, Dsl.CLIENT_SECRET, "test"))
        {
            var actual = await client.QuerySignatureOrder(
                "asd"
            );

            Assert.Null(actual);
        }
    }
}