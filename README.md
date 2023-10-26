A dotnet/C# SDK for Criipto Signatures

[Examples](https://docs.criipto.com/signatures/graphql/examples/)

## Getting started

### Installation

The SDK is available on [Nuget](https://www.nuget.org/packages/Criipto.Signatures) and can be installed using the Package Manager Console or the dotnet CLI:

```
Install-Package Criipto.Signatures
dotnet add package Criipto.Signatures
```

### Configure the SDK

```csharp
var client = new CriiptoSignaturesClient("{YOUR_CRIIPTO_CLIENT_ID}", "{YOUR_CRIIPTO_CLIENT_SECRET}");
```

## Basic example

```csharp
using Criipto.Signatures;
using Criipto.Signatures.Models;

using (var client = new CriiptoSignaturesClient("{YOUR_CRIIPTO_CLIENT_ID}", "{YOUR_CRIIPTO_CLIENT_SECRET}")) {
    // Setup document input
    var documents = new List<DocumentInput>{
        new DocumentInput {
            pdf = new PadesDocumentInput {
                title = "Dotnet Sample",
                blob = pdf,
                storageMode = DocumentStorageMode.Temporary
            }
        }
    };

    // Setup signature order input
    var createSignatureOrderInput = new CreateSignatureOrderInput
    {
        title = "Dotnet Sample",
        documents = documents
    };

    // Create signature order
    var signatureOrder = await client.CreateSignatureOrder(createSignatureOrderInput);

    // Add signatory to signature order
    var addSignatory = await client.AddSignatory(signatureOrder);

    Console.WriteLine(addSignatory.href);

    // ... after signing
    // Close signature order
    var closedSignatureOrder = await client.CloseSignatureOrder(signatureOrder);
}
```

More examples can be found in the [test suite](https://github.com/criipto/criipto-signatures-dotnet/tree/master/Criipto.Signatures.IntegrationTests) and in the [documentation](https://docs.criipto.com/signatures/graphql/examples/)

## Methods

### QuerySignatureOrder

Will return a `Models.SignatureOrder` or null if signature order does not exist.

```csharp
using Criipto.Signatures;

using (var client = new CriiptoSignaturesClient("{YOUR_CRIIPTO_CLIENT_ID}", "{YOUR_CRIIPTO_CLIENT_SECRET}")) {
    var signatureOrder = await client.QuerySignatureOrder("{... signatureOrder id ..."});
}
```

### QuerySignatory

Will return a `Models.Signatory` or null if signatory does not exist.

```csharp
using Criipto.Signatures;

using (var client = new CriiptoSignaturesClient("{YOUR_CRIIPTO_CLIENT_ID}", "{YOUR_CRIIPTO_CLIENT_SECRET}")) {
    var signatureOrder = await client.QuerySignatory("{... signatory id ..."});
}
```