using Serverless.Helper;
using HttpMultipartParser;
using Amazon.Lambda.APIGatewayEvents;

namespace Serverless.Handler
{
    public static class FormDataHandler
    {
        public static async Task<T?> HandleFormData<T>(APIGatewayHttpApiV2ProxyRequest request) where T : new()
        {
            var contentType = request.Headers["content-type"];
            var bodyBytes = Convert.FromBase64String(request.Body);

            using var stream = new MemoryStream(bodyBytes);
            var parser = await MultipartFormDataParser.ParseAsync(stream, contentType);

            var input = MultipartBinder.Bind<T>(parser);

            return input;
        }
    }
}
