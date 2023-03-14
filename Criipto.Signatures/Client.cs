using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Net.Http.Headers;

namespace Criipto.Signatures;
public class CriiptoSignaturesClient : IDisposable
{
    private readonly GraphQLHttpClient graphQLClient;
    private bool isDisposed;

    public CriiptoSignaturesClient(
        string clientId,
        string clientSecret,
        string endpoint = "https://signatures-api.criipto.com/v1/graphql"
    )
    {
        this.graphQLClient =
            new GraphQLHttpClient(
                endpoint, new NewtonsoftJsonSerializer()
            );

        this.graphQLClient.HttpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue(
                "Basic",
                Convert.ToBase64String(
                    System.Text.Encoding.ASCII.GetBytes(
                        $"{clientId}:{clientSecret}"
                    )
                )
            );
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (this.isDisposed) return;

        if (disposing)
        {
            this.graphQLClient.Dispose();
        }

        this.isDisposed = true;
    }

    public async Task<Types.SignatureOrder> CreateSignatureOrder(Types.CreateSignatureOrderInput input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));

        var response = await graphQLClient.SendMutationAsync(
            CreateSignatureOrderMutation.Request(new { input = input }),
            () => new { createSignatureOrder = new Types.CreateSignatureOrderOutput() }
        ).ConfigureAwait(false);

        if (response.Errors?.Length > 0)
        {
            throw new GraphQLException(response.Errors[0].Message);
        }

        return response.Data.createSignatureOrder.signatureOrder;
    }

    public async Task<Types.Signatory> AddSignatory(Types.AddSignatoryInput input)
    {
        var response = await graphQLClient.SendMutationAsync(
            AddSignatoryMutation.Request(new { input = input }),
            () => new { addSignatory = new Types.AddSignatoryOutput() }
        ).ConfigureAwait(false);

        if (response.Errors?.Length > 0)
        {
            throw new GraphQLException(response.Errors[0].Message);
        }

        return response.Data.addSignatory.signatory;
    }

    public async Task<Types.Signatory> AddSignatory(Types.SignatureOrder signatureOrder)
    {
        if (signatureOrder == null) throw new ArgumentNullException(nameof(signatureOrder));

        var input = new Types.AddSignatoryInput();
        input.signatureOrderId = signatureOrder.id;
        return await AddSignatory(input).ConfigureAwait(false);
    }

    public async Task<Types.Signatory> AddSignatory(Types.SignatureOrder signatureOrder, Types.AddSignatoryInput input)
    {
        if (signatureOrder == null) throw new ArgumentNullException(nameof(signatureOrder));
        if (input == null) throw new ArgumentNullException(nameof(input));

        input.signatureOrderId = signatureOrder.id;
        return await AddSignatory(input).ConfigureAwait(false);
    }

    public async Task<Types.Signatory> AddSignatory(string signatureOrderId)
    {
        if (signatureOrderId == null) throw new ArgumentNullException(nameof(signatureOrderId));

        var input = new Types.AddSignatoryInput();
        input.signatureOrderId = signatureOrderId;
        return await AddSignatory(input).ConfigureAwait(false);
    }

    public async Task<Types.Signatory> AddSignatory(string signatureOrderId, Types.AddSignatoryInput input)
    {
        if (signatureOrderId == null) throw new ArgumentNullException(nameof(signatureOrderId));
        if (input == null) throw new ArgumentNullException(nameof(input));

        input.signatureOrderId = signatureOrderId;
        return await AddSignatory(input).ConfigureAwait(false);
    }

    public async Task<Types.SignatureOrder> CloseSignatureOrder(Types.CloseSignatureOrderInput input)
    {
        var response = await graphQLClient.SendMutationAsync(
            CloseSignatureOrderMutation.Request(new { input = input }),
            () => new { closeSignatureOrder = new Types.CloseSignatureOrderOutput() }
        ).ConfigureAwait(false);

        if (response.Errors?.Length > 0)
        {
            throw new GraphQLException(response.Errors[0].Message);
        }

        return response.Data.closeSignatureOrder.signatureOrder;
    }

    public async Task<Types.SignatureOrder> CloseSignatureOrder(Types.SignatureOrder signatureOrder)
    {
        if (signatureOrder == null) throw new ArgumentNullException(nameof(signatureOrder));

        var input = new Types.CloseSignatureOrderInput();
        input.signatureOrderId = signatureOrder.id;
        return await CloseSignatureOrder(input).ConfigureAwait(false);
    }

    public async Task<Types.SignatureOrder> CloseSignatureOrder(Types.SignatureOrder signatureOrder, Types.CloseSignatureOrderInput input)
    {
        if (signatureOrder == null) throw new ArgumentNullException(nameof(signatureOrder));
        if (input == null) throw new ArgumentNullException(nameof(input));

        input.signatureOrderId = signatureOrder.id;
        return await CloseSignatureOrder(input).ConfigureAwait(false);
    }

    public async Task<Types.SignatureOrder> CloseSignatureOrder(string signatureOrderId)
    {
        if (signatureOrderId == null) throw new ArgumentNullException(nameof(signatureOrderId));

        var input = new Types.CloseSignatureOrderInput();
        input.signatureOrderId = signatureOrderId;
        return await CloseSignatureOrder(input).ConfigureAwait(false);
    }

    public async Task<Types.SignatureOrder> CloseSignatureOrder(string signatureOrderId, Types.CloseSignatureOrderInput input)
    {
        if (signatureOrderId == null) throw new ArgumentNullException(nameof(signatureOrderId));
        if (input == null) throw new ArgumentNullException(nameof(input));

        input.signatureOrderId = signatureOrderId;
        return await CloseSignatureOrder(input).ConfigureAwait(false);
    }

    public async Task<Types.SignatureOrder?> QuerySignatureOrder(string signatureOrderId, bool includeDocuments = false)
    {
        if (signatureOrderId == null) throw new ArgumentNullException(nameof(signatureOrderId));

        var request =
            includeDocuments == true ?
                SignatureOrderWithDocumentsQuery.Request(new { id = signatureOrderId }) :
                SignatureOrderQuery.Request(new { id = signatureOrderId });

        var response = await graphQLClient.SendQueryAsync<Types.Query>(
            request
        ).ConfigureAwait(false);

        if (response.Errors?.Length > 0)
        {
            throw new GraphQLException(response.Errors[0].Message);
        }

        return response.Data.signatureOrder;
    }
}