using System.Text.Json;
using System.Diagnostics.CodeAnalysis;

namespace Serverless.Handler
{
    public static class SerializerHandle
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static TValue? Deserialize<TValue>([StringSyntax(StringSyntaxAttribute.Json)] string json)
        {
            return JsonSerializer.Deserialize<TValue>(json, _jsonOptions);
        }
    }
}
