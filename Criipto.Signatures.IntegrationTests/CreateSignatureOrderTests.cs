using Xunit;
using Criipto.Signatures;
using System.Collections.Generic;
using System.IO;
namespace Criipto.Signatures.IntegrationTests;

public class CreateSignatureOrderTests
{
    public static string CLIENT_ID = System.Environment.GetEnvironmentVariable("CRIIPTO_SIGNATURES_CLIENT_ID")!;
    public static string CLIENT_SECRET = System.Environment.GetEnvironmentVariable("CRIIPTO_SIGNATURES_CLIENT_SECRET")!;
    public static byte[] Sample = File.ReadAllBytes("./sample.pdf");

    [Fact]
    public void ClientCredentialsSet() {
        Assert.NotNull(CLIENT_ID);
        Assert.NotNull(CLIENT_SECRET);
    }

    [Fact]
    public async void MutationThrowsAuthorizationError()
    {
        using (var client = new CriiptoSignaturesClient("invalid", "invalid"))
        {
            var exn = await Assert.ThrowsAsync<GraphQLException>(() => client.CreateSignatureOrder(new Types.CreateSignatureOrderInput() {
                title = "Title",
                documents = new List<Types.DocumentInput>()
            }));
            Assert.Equal("Unauthorized access", exn.Message);
        }
    }

    [Fact]
    public async void MutationThrowsValidationError() {
        using (var client = new CriiptoSignaturesClient(CLIENT_ID, CLIENT_SECRET))
        {
            var exn = await Assert.ThrowsAsync<GraphQLException>(() => client.CreateSignatureOrder(new Types.CreateSignatureOrderInput() {
                title = "Title",
                documents = new List<Types.DocumentInput>(){
                    new Types.DocumentInput {
                        pdf = new Types.PadesDocumentInput {
                            title = "TEST",
                            blob = new byte[0]
                        }
                    }
                }
            }));
            Assert.Equal("Document TEST does not appear to be a PDF", exn.Message);
        }
    }

    [Fact]
    public async void MutationReturnsSignatureOrder() {
        using (var client = new CriiptoSignaturesClient(CLIENT_ID, CLIENT_SECRET))
        {
            var signatureOrder = await client.CreateSignatureOrder(new Types.CreateSignatureOrderInput() {
                title = "Title",
                expiresInDays = 1,
                documents = new List<Types.DocumentInput>(){
                    new Types.DocumentInput {
                        pdf = new Types.PadesDocumentInput {
                            title = "TEST",
                            blob = Sample
                        }
                    }
                }
            });

            Assert.NotNull(signatureOrder?.id);
        }
    }
}