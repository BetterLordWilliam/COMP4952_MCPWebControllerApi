using System;
using System.Text.Json.Serialization;

using MCPWebControllerApi.Models;

namespace MCPWebControllerApi.Services;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(List<Beverage>))]
[JsonSerializable(typeof(Beverage))]
internal sealed partial class BeverageContext : JsonSerializerContext
{
}
