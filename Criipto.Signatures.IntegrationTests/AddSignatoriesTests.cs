using Xunit;
using Criipto.Signatures;
using Criipto.Signatures.Models;
using System.Collections.Generic;
using System.IO;
namespace Criipto.Signatures.IntegrationTests;

public class AddSignatoriesTests
{

    [Fact]
    public async void MutationReturnsSignatories()
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
            var signatories = await client.AddSignatories(
                signatureOrder,
                new() {
                    new CreateSignatureOrderSignatoryInput() {
                        role = "Chairman"
                    },
                    new CreateSignatureOrderSignatoryInput() {
                        role = "Director"
                    }
                }
            );

            // Assert
            Assert.Equal(2, signatories.Count);
        }
    }
}