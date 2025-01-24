using System.Text.Json.Serialization;
using PaddleBilling.Models.API.v1.Resources;
using PaddleBilling.Models.API.v1.Resources.Customers;

namespace PaddleBilling.Models.Json.Aot;

[JsonSerializable(typeof(string))]
[JsonSerializable(typeof(Dictionary<string, string>))]
[JsonSerializable(typeof(Entity))]
[JsonSerializable(typeof(DateTimeOffset))]
[JsonSerializable(typeof(ImportMeta))]
[JsonSerializable(typeof(Address))]
public partial class PaddleBillingJsonSerializerContext : JsonSerializerContext
{
    
}