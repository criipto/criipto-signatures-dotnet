A dotnet/C# SDK for Criipto Signatures

## Getting started

### Requirements

This library supports .NET 6 and .NET 7.

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

using (var client = new CriiptoSignaturesClient("{YOUR_CRIIPTO_CLIENT_ID}", "{YOUR_CRIIPTO_CLIENT_SECRET}")) {
    // Setup document input
    var documents = new List<Types.DocumentInput>{
        new Types.DocumentInput {
            pdf = new Types.PadesDocumentInput {
                title = "Dotnet Sample",
                blob = pdf,
                storageMode = Types.DocumentStorageMode.Temporary
            }
        }
    };

    // Setup signature order input
    var createSignatureOrderInput = new Types.CreateSignatureOrderInput
    {
        title = "Dotnet Sample",
        documents = documents
    };

    // Create signature order
    var signatureOrder = await client.CreateSignatureOrder(createSignatureOrderInput);

    // Add signatory to signature order
    var addSignatory = await client.AddSignatory(signatureOrder);

    Console.WriteLine(addSignatory.href);
}
```