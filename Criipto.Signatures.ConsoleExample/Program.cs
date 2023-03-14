using Criipto.Signatures;

// Run sample with `CRIIPTO_SIGNATURES_CLIENT_ID=... CRIIPTO_SIGNATURES_CLIENT_SECRET=... dotnet run`
var clientId = Environment.GetEnvironmentVariable("CRIIPTO_SIGNATURES_CLIENT_ID");
var clientSecret = Environment.GetEnvironmentVariable("CRIIPTO_SIGNATURES_CLIENT_SECRET");

if (clientId == null) throw new ArgumentNullException("CRIIPTO_SIGNATURES_CLIENT_ID");
if (clientSecret == null) throw new ArgumentNullException("CRIIPTO_SIGNATURES_CLIENT_SECRET");

var pdf = File.ReadAllBytes("./sample.pdf");

using (var client = new CriiptoSignaturesClient(clientId, clientSecret))
{
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

    // Print link to signatory signing page to console
    Console.WriteLine($"Signature signing link: {addSignatory.href}\n\n");

    // Await completion of signature order
    signatureOrder = await pollSignatureOrderComplete(client, signatureOrder.id);
    Console.WriteLine("Signature signed!");

    // Check if all signatories signed without rejecting or errors
    foreach (var signatory in signatureOrder.signatories)
    {
        if (signatory.status == Types.SignatoryStatus.ERROR || signatory.status == Types.SignatoryStatus.REJECTED)
            throw new Exception("A signatory failed or declined to sign");
    }

    // Close signature order
    var closedSignatureOrder = await client.CloseSignatureOrder(signatureOrder);
    // Print signed documents to console
    foreach (var document in closedSignatureOrder.documents)
    {
        // Save blob to pdf file   
        var fileName = $"./output-{document.id.Substring(0, 8)}.pdf";
        Console.WriteLine($"Saving signed document to {fileName}");
        File.WriteAllBytes(fileName, document.blob);

        foreach (var signature in document.signatures)
        {
            if (signature is Types.JWTSignature jwtSignature)
            {
                Console.WriteLine($"JWT signature: {jwtSignature.jwt}");
            }
        }
    }
}

static async Task<Types.SignatureOrder> pollSignatureOrderComplete(CriiptoSignaturesClient client, string id)
{
    var signatureOrder = await client.QuerySignatureOrder(id);
    if (signatureOrder == null) throw new ArgumentNullException(nameof(signatureOrder));

    var allComplete =
        signatureOrder.signatories.Where(s => s.status != Types.SignatoryStatus.OPEN).Count()
        == signatureOrder.signatories.Count();

    if (allComplete) return signatureOrder;
    await Task.Delay(5000);
    return await pollSignatureOrderComplete(client, id);
}