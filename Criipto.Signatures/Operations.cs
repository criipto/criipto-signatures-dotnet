using System;
using Newtonsoft.Json;
using GraphQL;
using GraphQL.Client.Abstractions;

namespace Criipto.Signatures {

    public class CreateSignatureOrderMutation {
      /// <summary>
      /// CreateSignatureOrderMutation.Request 
      /// <para>Required variables:<br/> { input=(CreateSignatureOrderInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = CreateSignatureOrderDocument,
          OperationName = "createSignatureOrder",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getCreateSignatureOrderMutation() {
        return Request();
      }
      
      public static string CreateSignatureOrderDocument = @"
        mutation createSignatureOrder($input: CreateSignatureOrderInput!) {
          createSignatureOrder(input: $input) {
            signatureOrder {
              id
              documents {
                __typename
                id
              }
              signatories {
                id
                status
              }
            }
          }
        }
        ";
      
    }
    

    public class SignatureOrderQuery {
      /// <summary>
      /// SignatureOrderQuery.Request 
      /// <para>Required variables:<br/> { id=(string) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = SignatureOrderDocument,
          OperationName = "signatureOrder",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSignatureOrderQuery() {
        return Request();
      }
      
      public static string SignatureOrderDocument = @"
        query signatureOrder($id: ID!) {
          signatureOrder(id: $id) {
            status
            signatories {
              id
              status
              href
            }
          }
        }
        ";
      
    }
    
}