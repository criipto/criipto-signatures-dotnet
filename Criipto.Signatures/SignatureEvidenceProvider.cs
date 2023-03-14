#pragma warning disable CS8618
#pragma warning disable CA1507
#pragma warning disable CA1707

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace Criipto.Signatures;

public class SignatureEvidenceProvider
{
    [JsonProperty("__typename")]
    public string __typename { get; set; }

    [JsonProperty("id")]
    public string id { get; set; }
}