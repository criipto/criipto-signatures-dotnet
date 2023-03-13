using Xunit;
using Criipto.Signatures;
using System.Collections.Generic;
using System.IO;
namespace Criipto.Signatures.IntegrationTests;

public class AddSignatoryTests
{

    [Fact]
    public async void MutationReturnsSignatory()
    {
        using (var client = new CriiptoSignaturesClient(Dsl.CLIENT_ID, Dsl.CLIENT_SECRET))
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
            var signatory = await client.AddSignatory(
                signatureOrder
            );

            // Assert
            Assert.NotNull(signatory?.id);
            Assert.NotNull(signatory?.href);
        }
    }
}