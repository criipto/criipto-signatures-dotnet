using Xunit;
using Criipto.Signatures;
using Criipto.Signatures.Models;
using System.Collections.Generic;
using System.Linq;
namespace Criipto.Signatures.IntegrationTests;

public class DeleteSignatoryTests
{

    [Fact]
    public async void MutationDeletesSignatory()
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
                    },
                }
            );

            var signatory = await client.AddSignatory(
                signatureOrder
            );

            // Act
            var actual = await client.DeleteSignatory(signatory);

            // Assert
            Assert.Empty(actual.signatories);
        }
    }
}