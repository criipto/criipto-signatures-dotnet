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
              ...BasicSignatureOrder
              documents {
                ...BasicDocument
              }
            }
          }
        }
        fragment BasicDocument on Document {
          __typename
          id
          title
          reference
        }
        fragment BasicSignatory on Signatory {
          id
          status
          href
          downloadHref
          reference
          role
          evidenceProviders {
            __typename
            id
          }
          documents {
            edges {
              status
              node {
                __typename
                id
              }
            }
          }
        }
        fragment BasicSignatureOrder on SignatureOrder {
          id
          status
          signatories {
            ...BasicSignatory
          }
          evidenceProviders {
            __typename
            id
          }
        }";
      
    }
    

    public class CleanupSignatureOrderMutation {
      /// <summary>
      /// CleanupSignatureOrderMutation.Request 
      /// <para>Required variables:<br/> { input=(CleanupSignatureOrderInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = CleanupSignatureOrderDocument,
          OperationName = "cleanupSignatureOrder",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getCleanupSignatureOrderMutation() {
        return Request();
      }
      
      public static string CleanupSignatureOrderDocument = @"
        mutation cleanupSignatureOrder($input: CleanupSignatureOrderInput!) {
          cleanupSignatureOrder(input: $input) {
            signatureOrder {
              ...BasicSignatureOrder
              documents {
                ...BasicDocument
              }
            }
          }
        }
        fragment BasicDocument on Document {
          __typename
          id
          title
          reference
        }
        fragment BasicSignatory on Signatory {
          id
          status
          href
          downloadHref
          reference
          role
          evidenceProviders {
            __typename
            id
          }
          documents {
            edges {
              status
              node {
                __typename
                id
              }
            }
          }
        }
        fragment BasicSignatureOrder on SignatureOrder {
          id
          status
          signatories {
            ...BasicSignatory
          }
          evidenceProviders {
            __typename
            id
          }
        }";
      
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
              ...BasicSignatory
            }
          }
        }
        fragment BasicSignatory on Signatory {
          id
          status
          href
          downloadHref
          reference
          role
          evidenceProviders {
            __typename
            id
          }
          documents {
            edges {
              status
              node {
                __typename
                id
              }
            }
          }
        }";
      
    }
    

    public class AddSignatoriesMutation {
      /// <summary>
      /// AddSignatoriesMutation.Request 
      /// <para>Required variables:<br/> { input=(AddSignatoriesInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = AddSignatoriesDocument,
          OperationName = "addSignatories",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getAddSignatoriesMutation() {
        return Request();
      }
      
      public static string AddSignatoriesDocument = @"
        mutation addSignatories($input: AddSignatoriesInput!) {
          addSignatories(input: $input) {
            signatories {
              ...BasicSignatory
            }
          }
        }
        fragment BasicSignatory on Signatory {
          id
          status
          href
          downloadHref
          reference
          role
          evidenceProviders {
            __typename
            id
          }
          documents {
            edges {
              status
              node {
                __typename
                id
              }
            }
          }
        }";
      
    }
    

    public class ChangeSignatoryMutation {
      /// <summary>
      /// ChangeSignatoryMutation.Request 
      /// <para>Required variables:<br/> { input=(ChangeSignatoryInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = ChangeSignatoryDocument,
          OperationName = "changeSignatory",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getChangeSignatoryMutation() {
        return Request();
      }
      
      public static string ChangeSignatoryDocument = @"
        mutation changeSignatory($input: ChangeSignatoryInput!) {
          changeSignatory(input: $input) {
            signatory {
              ...BasicSignatory
            }
          }
        }
        fragment BasicSignatory on Signatory {
          id
          status
          href
          downloadHref
          reference
          role
          evidenceProviders {
            __typename
            id
          }
          documents {
            edges {
              status
              node {
                __typename
                id
              }
            }
          }
        }";
      
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
              ...BasicSignatureOrder
              documents {
                ...BasicDocument
                ...SignedDocument
              }
            }
          }
        }
        fragment BasicDocument on Document {
          __typename
          id
          title
          reference
        }
        fragment SignedDocument on Document {
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
        fragment BasicSignatory on Signatory {
          id
          status
          href
          downloadHref
          reference
          role
          evidenceProviders {
            __typename
            id
          }
          documents {
            edges {
              status
              node {
                __typename
                id
              }
            }
          }
        }
        fragment BasicSignatureOrder on SignatureOrder {
          id
          status
          signatories {
            ...BasicSignatory
          }
          evidenceProviders {
            __typename
            id
          }
        }";
      
    }
    

    public class CancelSignatureOrderMutation {
      /// <summary>
      /// CancelSignatureOrderMutation.Request 
      /// <para>Required variables:<br/> { input=(CancelSignatureOrderInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = CancelSignatureOrderDocument,
          OperationName = "cancelSignatureOrder",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getCancelSignatureOrderMutation() {
        return Request();
      }
      
      public static string CancelSignatureOrderDocument = @"
        mutation cancelSignatureOrder($input: CancelSignatureOrderInput!) {
          cancelSignatureOrder(input: $input) {
            signatureOrder {
              ...BasicSignatureOrder
              documents {
                ...BasicDocument
              }
            }
          }
        }
        fragment BasicDocument on Document {
          __typename
          id
          title
          reference
        }
        fragment BasicSignatory on Signatory {
          id
          status
          href
          downloadHref
          reference
          role
          evidenceProviders {
            __typename
            id
          }
          documents {
            edges {
              status
              node {
                __typename
                id
              }
            }
          }
        }
        fragment BasicSignatureOrder on SignatureOrder {
          id
          status
          signatories {
            ...BasicSignatory
          }
          evidenceProviders {
            __typename
            id
          }
        }";
      
    }
    

    public class SignActingAsMutation {
      /// <summary>
      /// SignActingAsMutation.Request 
      /// <para>Required variables:<br/> { input=(SignActingAsInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = SignActingAsDocument,
          OperationName = "signActingAs",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getSignActingAsMutation() {
        return Request();
      }
      
      public static string SignActingAsDocument = @"
        mutation signActingAs($input: SignActingAsInput!) {
          signActingAs(input: $input) {
            signatory {
              ...BasicSignatory
            }
          }
        }
        fragment BasicSignatory on Signatory {
          id
          status
          href
          downloadHref
          reference
          role
          evidenceProviders {
            __typename
            id
          }
          documents {
            edges {
              status
              node {
                __typename
                id
              }
            }
          }
        }";
      
    }
    

    public class ValidateDocumentMutation {
      /// <summary>
      /// ValidateDocumentMutation.Request 
      /// <para>Required variables:<br/> { input=(ValidateDocumentInput) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = ValidateDocumentDocument,
          OperationName = "validateDocument",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getValidateDocumentMutation() {
        return Request();
      }
      
      public static string ValidateDocumentDocument = @"
        mutation validateDocument($input: ValidateDocumentInput!) {
          validateDocument(input: $input) {
            valid
            errors
            fixable
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
            ...BasicSignatureOrder
          }
        }
        fragment BasicSignatory on Signatory {
          id
          status
          href
          downloadHref
          reference
          role
          evidenceProviders {
            __typename
            id
          }
          documents {
            edges {
              status
              node {
                __typename
                id
              }
            }
          }
        }
        fragment BasicSignatureOrder on SignatureOrder {
          id
          status
          signatories {
            ...BasicSignatory
          }
          evidenceProviders {
            __typename
            id
          }
        }";
      
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
            ...BasicSignatureOrder
            documents {
              ...BasicDocument
              ...SignedDocument
            }
          }
        }
        fragment BasicDocument on Document {
          __typename
          id
          title
          reference
        }
        fragment SignedDocument on Document {
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
        fragment BasicSignatory on Signatory {
          id
          status
          href
          downloadHref
          reference
          role
          evidenceProviders {
            __typename
            id
          }
          documents {
            edges {
              status
              node {
                __typename
                id
              }
            }
          }
        }
        fragment BasicSignatureOrder on SignatureOrder {
          id
          status
          signatories {
            ...BasicSignatory
          }
          evidenceProviders {
            __typename
            id
          }
        }";
      
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
            ...BasicSignatory
            signatureOrder {
              ...BasicSignatureOrder
            }
          }
        }
        fragment BasicSignatory on Signatory {
          id
          status
          href
          downloadHref
          reference
          role
          evidenceProviders {
            __typename
            id
          }
          documents {
            edges {
              status
              node {
                __typename
                id
              }
            }
          }
        }
        fragment BasicSignatureOrder on SignatureOrder {
          id
          status
          signatories {
            ...BasicSignatory
          }
          evidenceProviders {
            __typename
            id
          }
        }";
      
    }
    
}