using Xunit;
using Criipto.Signatures;
using Criipto.Signatures.Models;
using System.Collections.Generic;
using System.IO;
namespace Criipto.Signatures.IntegrationTests;

public class CloseSignatureOrderTests
{
    [Fact]
    public async void MutationReturnsSignatureOrder()
    {
        using (var client = new CriiptoSignaturesClient(Dsl.CLIENT_ID, Dsl.CLIENT_SECRET, "test"))
        {
            // Arrange
            var signatureOrder = await client.CreateSignatureOrder(
                new CreateSignatureOrderInput()
                {
                    title = "Title",
                    expiresInDays = 1,
                    documents = new List<DocumentInput>(){
                        new DocumentInput {
                            pdf =
                                new PadesDocumentInput
                                {
                                    title = "TEST",
                                    blob = Dsl.Sample
                                }
                        }
                    }
                }
            );

            // Act
            var actual = await client.CloseSignatureOrder(
                signatureOrder
            );

            // Assert
            Assert.NotNull(actual?.id);
        }
    }
}