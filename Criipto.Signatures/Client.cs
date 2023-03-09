using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Net.Http.Headers;

namespace Criipto.Signatures
{
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
    }
}