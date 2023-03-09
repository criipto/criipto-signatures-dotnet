using Xunit;
using Criipto.Signatures;
using System.Collections.Generic;
using System.IO;
namespace Criipto.Signatures.IntegrationTests;

public class AddSignatoryTests
{
    public static string CLIENT_ID = System.Environment.GetEnvironmentVariable("CRIIPTO_SIGNATURES_CLIENT_ID")!;
    public static string CLIENT_SECRET = System.Environment.GetEnvironmentVariable("CRIIPTO_SIGNATURES_CLIENT_SECRET")!;
    public static byte[] Sample = File.ReadAllBytes("./sample.pdf");

    [Fact]
    public void ClientCredentialsSet()
    {
        Assert.NotNull(CLIENT_ID);
        Assert.NotNull(CLIENT_SECRET);
    }

    [Fact]
    public async void MutationReturnsSignatory()
    {
        using (var client = new CriiptoSignaturesClient(CLIENT_ID, CLIENT_SECRET))
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
                                    blob = Sample
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
        }
    }
}