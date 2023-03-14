using Xunit;
using Criipto.Signatures;
using System.Collections.Generic;
using System.IO;
namespace Criipto.Signatures.IntegrationTests;

public class CreateSignatureOrderTests
{
    [Fact]
    public async void MutationThrowsAuthorizationError()
    {
        using (var client = new CriiptoSignaturesClient("invalid", "invalid"))
        {
            var exn = await Assert.ThrowsAsync<GraphQLException>(() =>
                client.CreateSignatureOrder(
                    new Types.CreateSignatureOrderInput()
                    {
                        title = "Title",
                        documents = new List<Types.DocumentInput>()
                    }
                )
            );
            Assert.Equal("Unauthorized access", exn.Message);
        }
    }

    [Fact]
    public async void MutationThrowsValidationError()
    {
        using (var client = new CriiptoSignaturesClient(Dsl.CLIENT_ID, Dsl.CLIENT_SECRET, "test"))
        {
            var exn = await Assert.ThrowsAsync<GraphQLException>(() =>
                client.CreateSignatureOrder(
                    new Types.CreateSignatureOrderInput()
                    {
                        title = "Title",
                        documents = new List<Types.DocumentInput>()
                        {
                            new Types.DocumentInput {
                                pdf =
                                    new Types.PadesDocumentInput
                                    {
                                        title = "TEST",
                                        blob = new byte[0]
                                    }
                            }
                        }
                    }
                )
            );
            Assert.Equal("Document TEST does not appear to be a PDF", exn.Message);
        }
    }

    [Fact]
    public async void MutationReturnsSignatureOrder()
    {
        using (var client = new CriiptoSignaturesClient(Dsl.CLIENT_ID, Dsl.CLIENT_SECRET, "test"))
        {
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

            Assert.NotNull(signatureOrder?.id);
        }
    }
}