using Xunit;
using Criipto.Signatures;
using Criipto.Signatures.Models;
using System.Collections.Generic;
using System.Linq;
namespace Criipto.Signatures.IntegrationTests;

public class SignActingAsTests
{

    [Fact]
    public async void MutationSigns()
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

            var signatory = await client.AddSignatory(
                signatureOrder,
                new AddSignatoryInput()
                {
                    documents = signatureOrder.documents.Select(d => new SignatoryDocumentInput()
                    {
                        id = d.id,
                        preapproved = true
                    }).ToList()
                }
            );

            var drawable =
                signatureOrder!.evidenceProviders
                    .Where(e => e is DrawableSignatureEvidenceProvider)
                    .First();

            // Act
            var actual = await client.SignActingAs(
                signatory,
                new SignActingAsInput()
                {
                    evidence = new SignInput()
                    {
                        id = drawable.id,
                        drawable = new SignDrawableInput()
                        {
                            name = "Example Name",
                            image = System.Convert.FromBase64String("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")
                        }
                    }
                }
            );

            // Assert
            Assert.Equal(SignatoryStatus.SIGNED, actual.status);
        }
    }
}