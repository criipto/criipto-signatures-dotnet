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

    public async Task<Types.SignatureOrder> CreateSignatureOrder(Types.CreateSignatureOrderInput input) {
        var response = await graphQLClient.SendMutationAsync(
            CreateSignatureOrderMutation.Request(new { input = input}),
            () => new {createSignatureOrder = new Types.CreateSignatureOrderOutput()}
        ).ConfigureAwait(false);
        
        if (response.Errors?.Length > 0) {
            throw new GraphQLException(response.Errors[0].Message);
        }

        return response.Data.createSignatureOrder.signatureOrder;
    }
}