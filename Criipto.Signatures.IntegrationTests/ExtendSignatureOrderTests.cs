using Xunit;
using Criipto.Signatures;
using Criipto.Signatures.Models;
using System.Collections.Generic;
using System.IO;
using System;
namespace Criipto.Signatures.IntegrationTests;

public class ExtendSignatureOrderTests
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
            var actual = await client.ExtendSignatureOrder(
                signatureOrder,
                new ExtendSignatureOrderInput
                {
                    additionalExpirationInDays = 7
                }
            );

            // Assert
            Assert.NotNull(actual?.id);
            Assert.Equal(DateTimeOffset.Parse(actual!.expiresAt), DateTimeOffset.Parse(signatureOrder.expiresAt).AddDays(7));
        }
    }
}