using Xunit;
using System.Threading.Tasks;
using Criipto.Signatures.Models;

namespace Criipto.Signatures.IntegrationTests;

public class CreateBatchSignatoryTests
{
    private static async Task<(SignatureOrder, Signatory)> CreateSignatoryPair(CriiptoSignaturesClient client)
    {
        var signatureOrder = await client.CreateSignatureOrder(
            new CreateSignatureOrderInput()
            {
                title = "Title",
                expiresInDays = 1,
                documents =
                [
                    new DocumentInput {
                        pdf =
                            new PadesDocumentInput
                            {
                                title = "TEST",
                                blob = Dsl.Sample
                            }
                    }
                ]
            }
        );

        var signatory = await client.AddSignatory(signatureOrder);

        return (signatureOrder, signatory);
    }

    [Fact]
    public async Task MutationReturnsBatchSignatory()
    {
        // arrange
        using var client = new CriiptoSignaturesClient(Dsl.CLIENT_ID, Dsl.CLIENT_SECRET, "test");

        // create the signatory pairs for the batch signatory
        var (signatureOrderA, signatoryA) = await CreateSignatoryPair(client);
        var (signatureOrderB, signatoryB) = await CreateSignatoryPair(client);

        var createBatchSignatoryInput = new CreateBatchSignatoryInput
        {
            items = [
                new BatchSignatoryItemInput { signatoryId = signatoryA.id, signatureOrderId = signatureOrderA.id },
                new BatchSignatoryItemInput { signatoryId = signatoryB.id, signatureOrderId = signatureOrderB.id }
            ]
        };

        // act
        var batchSignatory = await client.CreateBatchSignatory(createBatchSignatoryInput);

        // assert
        Assert.NotEmpty(batchSignatory.href);

        Assert.Equal(createBatchSignatoryInput.items.Count, batchSignatory.items.Count);
    }

    [Fact]
    public async Task QueryReturnsBatchSignatory()
    {
        // arrange
        using var client = new CriiptoSignaturesClient(Dsl.CLIENT_ID, Dsl.CLIENT_SECRET, "test");

        // create the signatory pairs for the batch signatory
        var (signatureOrderA, signatoryA) = await CreateSignatoryPair(client);
        var (signatureOrderB, signatoryB) = await CreateSignatoryPair(client);

        var createBatchSignatoryInput = new CreateBatchSignatoryInput
        {
            items = [
                new BatchSignatoryItemInput { signatoryId = signatoryA.id, signatureOrderId = signatureOrderA.id },
                new BatchSignatoryItemInput { signatoryId = signatoryB.id, signatureOrderId = signatureOrderB.id }
            ]
        };

        var createBatchSignatory = await client.CreateBatchSignatory(createBatchSignatoryInput);

        // act
        var queriedBatchSignatory = await client.QueryBatchSignatory(createBatchSignatory.id);

        // assert
        Assert.NotNull(queriedBatchSignatory);

        Assert.Equal(createBatchSignatory.token, queriedBatchSignatory.token);
    }
}