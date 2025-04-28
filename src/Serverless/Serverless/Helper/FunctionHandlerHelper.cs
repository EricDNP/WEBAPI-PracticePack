using Serverless.Handler;
using Amazon.Lambda.APIGatewayEvents;
using System.Text.Json;

namespace Serverless.Helper
{
    public static class FunctionHandlerHelper
    {
        public static async Task<APIGatewayHttpApiV2ProxyResponse> HandleFunction (Func<Task<APIGatewayHttpApiV2ProxyResponse>> func)
        {
            try
            {
                return await func();
            }
            catch (UnauthorizedAccessException)
            {
                return ErrorHandler.HandleUnauthorized();
            }
            catch (KeyNotFoundException ex)
            {
                return ErrorHandler.NotFound(ex);
            }
            catch (Exception ex)
            {
                return ErrorHandler.HandleException(ex);
            }
        }
        public static void HandleLog(APIGatewayHttpApiV2ProxyRequest request)
        {
            Console.WriteLine("Path Received: " + request.RawPath);
            Console.WriteLine("Query Received: " + request.RawQueryString);
            Console.WriteLine("Body received: " + request.Body);
        }
    }
}
