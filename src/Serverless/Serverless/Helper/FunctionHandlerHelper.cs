using Serverless.Handler;
using Amazon.Lambda.APIGatewayEvents;

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
            catch (Exception ex)
            {
                return ErrorHandler.HandleException(ex);
            }
        }
    }
}
