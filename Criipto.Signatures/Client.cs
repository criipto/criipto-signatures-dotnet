using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Net.Http.Headers;
using Criipto.Signatures.Models;

namespace Criipto.Signatures;
public class CriiptoSignaturesClient : IDisposable
{
    private readonly GraphQLHttpClient graphQLClient;
    private bool isDisposed;

    public CriiptoSignaturesClient(
        string clientId,
        string clientSecret,
        string criiptoSdk
    )
    {
        this.graphQLClient =
            new GraphQLHttpClient(
                "https://signatures-api.criipto.com/v1/graphql", new NewtonsoftJsonSerializer()
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
        this.graphQLClient.HttpClient.DefaultRequestHeaders.Add(
            "Criipto-Sdk",
            criiptoSdk
        );
    }

    public CriiptoSignaturesClient(
        string clientId,
        string clientSecret
    ) : this(
        clientId,
        clientSecret,
        "criipto-signatures-dotnet"
    )
    { }

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

    public async Task<SignatureOrder> CreateSignatureOrder(CreateSignatureOrderInput input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));

        var response = await graphQLClient.SendMutationAsync(
            CreateSignatureOrderMutation.Request(new { input = input }),
            () => new { createSignatureOrder = new CreateSignatureOrderOutput() }
        ).ConfigureAwait(false);

        if (response.Errors?.Length > 0)
        {
            throw new GraphQLException(response.Errors[0].Message);
        }

        return response.Data.createSignatureOrder.signatureOrder;
    }

    public async Task<Signatory> AddSignatory(AddSignatoryInput input)
    {
        var response = await graphQLClient.SendMutationAsync(
            AddSignatoryMutation.Request(new { input = input }),
            () => new { addSignatory = new AddSignatoryOutput() }
        ).ConfigureAwait(false);

        if (response.Errors?.Length > 0)
        {
            throw new GraphQLException(response.Errors[0].Message);
        }

        return response.Data.addSignatory.signatory;
    }

    public async Task<Signatory> AddSignatory(SignatureOrder signatureOrder)
    {
        if (signatureOrder == null) throw new ArgumentNullException(nameof(signatureOrder));

        var input = new AddSignatoryInput();
        input.signatureOrderId = signatureOrder.id;
        return await AddSignatory(input).ConfigureAwait(false);
    }

    public async Task<Signatory> AddSignatory(SignatureOrder signatureOrder, AddSignatoryInput input)
    {
        if (signatureOrder == null) throw new ArgumentNullException(nameof(signatureOrder));
        if (input == null) throw new ArgumentNullException(nameof(input));

        input.signatureOrderId = signatureOrder.id;
        return await AddSignatory(input).ConfigureAwait(false);
    }

    public async Task<Signatory> AddSignatory(string signatureOrderId)
    {
        if (signatureOrderId == null) throw new ArgumentNullException(nameof(signatureOrderId));

        var input = new AddSignatoryInput();
        input.signatureOrderId = signatureOrderId;
        return await AddSignatory(input).ConfigureAwait(false);
    }

    public async Task<Signatory> AddSignatory(string signatureOrderId, AddSignatoryInput input)
    {
        if (signatureOrderId == null) throw new ArgumentNullException(nameof(signatureOrderId));
        if (input == null) throw new ArgumentNullException(nameof(input));

        input.signatureOrderId = signatureOrderId;
        return await AddSignatory(input).ConfigureAwait(false);
    }

    public async Task<SignatureOrder> CloseSignatureOrder(CloseSignatureOrderInput input)
    {
        var response = await graphQLClient.SendMutationAsync(
            CloseSignatureOrderMutation.Request(new { input = input }),
            () => new { closeSignatureOrder = new CloseSignatureOrderOutput() }
        ).ConfigureAwait(false);

        if (response.Errors?.Length > 0)
        {
            throw new GraphQLException(response.Errors[0].Message);
        }

        return response.Data.closeSignatureOrder.signatureOrder;
    }

    public async Task<SignatureOrder> CloseSignatureOrder(SignatureOrder signatureOrder)
    {
        if (signatureOrder == null) throw new ArgumentNullException(nameof(signatureOrder));

        var input = new CloseSignatureOrderInput();
        input.signatureOrderId = signatureOrder.id;
        return await CloseSignatureOrder(input).ConfigureAwait(false);
    }

    public async Task<SignatureOrder> CloseSignatureOrder(SignatureOrder signatureOrder, CloseSignatureOrderInput input)
    {
        if (signatureOrder == null) throw new ArgumentNullException(nameof(signatureOrder));
        if (input == null) throw new ArgumentNullException(nameof(input));

        input.signatureOrderId = signatureOrder.id;
        return await CloseSignatureOrder(input).ConfigureAwait(false);
    }

    public async Task<SignatureOrder> CloseSignatureOrder(string signatureOrderId)
    {
        if (signatureOrderId == null) throw new ArgumentNullException(nameof(signatureOrderId));

        var input = new CloseSignatureOrderInput();
        input.signatureOrderId = signatureOrderId;
        return await CloseSignatureOrder(input).ConfigureAwait(false);
    }

    public async Task<SignatureOrder> CloseSignatureOrder(string signatureOrderId, CloseSignatureOrderInput input)
    {
        if (signatureOrderId == null) throw new ArgumentNullException(nameof(signatureOrderId));
        if (input == null) throw new ArgumentNullException(nameof(input));

        input.signatureOrderId = signatureOrderId;
        return await CloseSignatureOrder(input).ConfigureAwait(false);
    }

    public async Task<SignatureOrder> CancelSignatureOrder(CancelSignatureOrderInput input)
    {
        var response = await graphQLClient.SendMutationAsync(
            CancelSignatureOrderMutation.Request(new { input = input }),
            () => new { cancelSignatureOrder = new CancelSignatureOrderOutput() }
        ).ConfigureAwait(false);

        if (response.Errors?.Length > 0)
        {
            throw new GraphQLException(response.Errors[0].Message);
        }

        return response.Data.cancelSignatureOrder.signatureOrder;
    }

    public async Task<SignatureOrder> CancelSignatureOrder(SignatureOrder signatureOrder)
    {
        if (signatureOrder == null) throw new ArgumentNullException(nameof(signatureOrder));

        var input = new CancelSignatureOrderInput();
        input.signatureOrderId = signatureOrder.id;
        return await CancelSignatureOrder(input).ConfigureAwait(false);
    }

    public async Task<SignatureOrder> CancelSignatureOrder(string signatureOrderId)
    {
        if (signatureOrderId == null) throw new ArgumentNullException(nameof(signatureOrderId));

        var input = new CancelSignatureOrderInput();
        input.signatureOrderId = signatureOrderId;
        return await CancelSignatureOrder(input).ConfigureAwait(false);
    }

    public async Task<SignatureOrder> CleanupSignatureOrder(CleanupSignatureOrderInput input)
    {
        var response = await graphQLClient.SendMutationAsync(
            CleanupSignatureOrderMutation.Request(new { input = input }),
            () => new { cleanupSignatureOrder = new CleanupSignatureOrderOutput() }
        ).ConfigureAwait(false);

        if (response.Errors?.Length > 0)
        {
            throw new GraphQLException(response.Errors[0].Message);
        }

        return response.Data.cleanupSignatureOrder.signatureOrder;
    }

    public async Task<SignatureOrder> CleanupSignatureOrder(SignatureOrder signatureOrder)
    {
        if (signatureOrder == null) throw new ArgumentNullException(nameof(signatureOrder));

        var input = new CleanupSignatureOrderInput();
        input.signatureOrderId = signatureOrder.id;
        return await CleanupSignatureOrder(input).ConfigureAwait(false);
    }

    public async Task<SignatureOrder> CleanupSignatureOrder(string signatureOrderId)
    {
        if (signatureOrderId == null) throw new ArgumentNullException(nameof(signatureOrderId));

        var input = new CleanupSignatureOrderInput();
        input.signatureOrderId = signatureOrderId;
        return await CleanupSignatureOrder(input).ConfigureAwait(false);
    }

    public async Task<SignatureOrder?> QuerySignatureOrder(string signatureOrderId, bool includeDocuments = false)
    {
        if (signatureOrderId == null) throw new ArgumentNullException(nameof(signatureOrderId));

        var request =
            includeDocuments == true ?
                SignatureOrderWithDocumentsQuery.Request(new { id = signatureOrderId }) :
                SignatureOrderQuery.Request(new { id = signatureOrderId });

        var response = await graphQLClient.SendQueryAsync<Query>(
            request
        ).ConfigureAwait(false);

        if (response.Errors?.Length > 0)
        {
            throw new GraphQLException(response.Errors[0].Message);
        }

        return response.Data.signatureOrder;
    }

    public async Task<Signatory?> QuerySignatory(string signatoryId)
    {
        if (signatoryId == null) throw new ArgumentNullException(nameof(signatoryId));

        var request = SignatoryQuery.Request(new { id = signatoryId });

        var response = await graphQLClient.SendQueryAsync<Query>(
            request
        ).ConfigureAwait(false);

        if (response.Errors?.Length > 0)
        {
            throw new GraphQLException(response.Errors[0].Message);
        }

        return response.Data.signatory;
    }
}