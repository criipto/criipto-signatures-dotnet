using Xunit;
using Criipto.Signatures;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Criipto.Signatures.IntegrationTests;

public class CreateSignatureOrderTests
{
    private static List<Types.DocumentInput> DefaultDocuments = new List<Types.DocumentInput>(){
        new Types.DocumentInput {
            pdf =
                new Types.PadesDocumentInput
                {
                    title = "TEST",
                    blob = Dsl.Sample
                }
        }
    };

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
                    documents = DefaultDocuments
                }
            );

            Assert.NotNull(signatureOrder?.id);
        }
    }

    [Fact]
    public async void MutationSupportsDrawable()
    {
        using (var client = new CriiptoSignaturesClient(Dsl.CLIENT_ID, Dsl.CLIENT_SECRET, "test"))
        {
            var signatureOrder = await client.CreateSignatureOrder(
                new Types.CreateSignatureOrderInput()
                {
                    title = "Title",
                    expiresInDays = 1,
                    documents = DefaultDocuments,
                    disableVerifyEvidenceProvider = true,
                    evidenceProviders = new List<Types.EvidenceProviderInput>() {
                        new Types.EvidenceProviderInput() {
                            enabledByDefault = true,
                            drawable = new Types.DrawableEvidenceProviderInput() {
                                requireName = true
                            }
                        }
                    }
                }
            );

            Assert.NotNull(signatureOrder?.id);

            var drawable =
                signatureOrder!.evidenceProviders
                    .Where(e => e is Types.DrawableSignatureEvidenceProvider)
                    .First();
            Assert.NotNull(signatureOrder?.id);
        }
    }
}