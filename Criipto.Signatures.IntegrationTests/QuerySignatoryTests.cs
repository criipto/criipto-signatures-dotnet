using Xunit;
using Criipto.Signatures;
using System.Collections.Generic;
using System.IO;
namespace Criipto.Signatures.IntegrationTests;

public class QuerySignatoryTests
{

    [Fact]
    public async void QueryReturnsSignatory()
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
            var signatory = await client.AddSignatory(signatureOrder);

            // Act
            var actual = await client.QuerySignatory(
                signatory.id
            );

            // Assert
            Assert.NotNull(actual?.id);
            Assert.Equal(signatory.id, actual!.id);
        }
    }

    [Fact]
    public async void QueryReturnsNullForUnknownSignatory()
    {
        using (var client = new CriiptoSignaturesClient(Dsl.CLIENT_ID, Dsl.CLIENT_SECRET, "test"))
        {
            var actual = await client.QuerySignatory(
                "asd"
            );

            Assert.Null(actual);
        }
    }
}