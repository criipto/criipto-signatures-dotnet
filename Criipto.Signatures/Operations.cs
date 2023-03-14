#pragma warning disable CS8625
#pragma warning disable CA1052
#pragma warning disable CA2211
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
              evidenceProviders {
                __typename
                ... on NoopSignatureEvidenceProvider {
                  id
                }
                ... on OidcJWTSignatureEvidenceProvider {
                  id
                }
                ... on CriiptoVerifySignatureEvidenceProvider {
                  id
                }
                ... on DrawableSignatureEvidenceProvider {
                  id
                }
              }
            }
          }
        }
        ";
      
    }
    

    public class AddSignatoryMutation {
      /// <summary>
      /// AddSignatoryMutation.Request 
      /// <para>Required variables:<br/> { input=(AddSignatoryInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = AddSignatoryDocument,
          OperationName = "addSignatory",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getAddSignatoryMutation() {
        return Request();
      }
      
      public static string AddSignatoryDocument = @"
        mutation addSignatory($input: AddSignatoryInput!) {
          addSignatory(input: $input) {
            signatory {
              id
              status
              href
            }
          }
        }
        ";
      
    }
    

    public class CloseSignatureOrderMutation {
      /// <summary>
      /// CloseSignatureOrderMutation.Request 
      /// <para>Required variables:<br/> { input=(CloseSignatureOrderInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = CloseSignatureOrderDocument,
          OperationName = "closeSignatureOrder",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getCloseSignatureOrderMutation() {
        return Request();
      }
      
      public static string CloseSignatureOrderDocument = @"
        mutation closeSignatureOrder($input: CloseSignatureOrderInput!) {
          closeSignatureOrder(input: $input) {
            signatureOrder {
              id
              signatories {
                id
                status
                downloadHref
              }
              documents {
                __typename
                id
                blob
                signatures {
                  __typename
                  signatory {
                    id
                  }
                  ... on JWTSignature {
                    jwt
                    jwks
                  }
                }
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
            id
            status
            signatories {
              id
              status
              href
              downloadHref
            }
          }
        }
        ";
      
    }
    

    public class SignatureOrderWithDocumentsQuery {
      /// <summary>
      /// SignatureOrderWithDocumentsQuery.Request 
      /// <para>Required variables:<br/> { id=(string) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = SignatureOrderWithDocumentsDocument,
          OperationName = "signatureOrderWithDocuments",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSignatureOrderWithDocumentsQuery() {
        return Request();
      }
      
      public static string SignatureOrderWithDocumentsDocument = @"
        query signatureOrderWithDocuments($id: ID!) {
          signatureOrder(id: $id) {
            id
            status
            signatories {
              id
              status
              href
              downloadHref
            }
            documents {
              __typename
              id
              blob
              signatures {
                __typename
                signatory {
                  id
                }
                ... on JWTSignature {
                  jwt
                  jwks
                }
              }
            }
          }
        }
        ";
      
    }
    

    public class SignatoryQuery {
      /// <summary>
      /// SignatoryQuery.Request 
      /// <para>Required variables:<br/> { id=(string) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = SignatoryDocument,
          OperationName = "signatory",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSignatoryQuery() {
        return Request();
      }
      
      public static string SignatoryDocument = @"
        query signatory($id: ID!) {
          signatory(id: $id) {
            id
            status
            href
            downloadHref
            signatureOrder {
              id
              status
              signatories {
                id
                status
                href
                downloadHref
              }
            }
          }
        }
        ";
      
    }
    
}