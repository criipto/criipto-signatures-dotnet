using Xunit;
using Criipto.Signatures;
using Criipto.Signatures.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Criipto.Signatures.IntegrationTests;

public class CreateSignatureOrderTests
{
    private static List<DocumentInput> DefaultDocuments = new List<DocumentInput>(){
        new DocumentInput {
            pdf =
                new PadesDocumentInput
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
                    new CreateSignatureOrderInput()
                    {
                        title = "Title",
                        documents = new List<DocumentInput>()
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
                    new CreateSignatureOrderInput()
                    {
                        title = "Title",
                        documents = new List<DocumentInput>()
                        {
                            new DocumentInput {
                                pdf =
                                    new PadesDocumentInput
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
                new CreateSignatureOrderInput()
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
                new CreateSignatureOrderInput()
                {
                    title = "Title",
                    expiresInDays = 1,
                    documents = DefaultDocuments,
                    disableVerifyEvidenceProvider = true,
                    evidenceProviders = new List<EvidenceProviderInput>() {
                        new EvidenceProviderInput() {
                            enabledByDefault = true,
                            drawable = new DrawableEvidenceProviderInput() {
                                requireName = true
                            }
                        }
                    }
                }
            );

            Assert.NotNull(signatureOrder?.id);

            var drawable =
                signatureOrder!.evidenceProviders
                    .Where(e => e is DrawableSignatureEvidenceProvider)
                    .First();
            Assert.NotNull(signatureOrder?.id);
        }
    }

    [Fact]
    public async void MutationSupportsComposite()
    {
        using (var client = new CriiptoSignaturesClient(Dsl.CLIENT_ID, Dsl.CLIENT_SECRET, "test"))
        {
            var signatureOrder = await client.CreateSignatureOrder(
                new CreateSignatureOrderInput()
                {
                    title = "Title",
                    expiresInDays = 1,
                    documents = DefaultDocuments,
                    disableVerifyEvidenceProvider = true,
                    evidenceProviders = new List<EvidenceProviderInput>() {
                        new EvidenceProviderInput() {
                            enabledByDefault = true,
                            allOf = new AllOfEvidenceProviderInput() {
                                providers = new List<SingleEvidenceProviderInput>() {
                                    new SingleEvidenceProviderInput() {
                                        criiptoVerify = new CriiptoVerifyProviderInput() {
                                            alwaysRedirect = true
                                        }
                                    },
                                    new SingleEvidenceProviderInput() {
                                        drawable = new DrawableEvidenceProviderInput() {
                                            requireName = false
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            );

            Assert.NotNull(signatureOrder?.id);

            var drawable =
                signatureOrder!.evidenceProviders
                    .Where(e => e is AllOfSignatureEvidenceProvider)
                    .First();
            Assert.NotNull(signatureOrder?.id);
        }
    }
}