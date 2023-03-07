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