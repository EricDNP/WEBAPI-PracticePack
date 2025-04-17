using System.Text.Json;
using Amazon.Lambda.APIGatewayEvents;

namespace Serverless.Handler
{
    public static class ErrorHandler
    {
        public static APIGatewayHttpApiV2ProxyResponse HandleGeneric(dynamic errorBody, int statusCode = 500)
        {
            Console.WriteLine("ERROR: " + JsonSerializer.Serialize(errorBody));

            return new APIGatewayHttpApiV2ProxyResponse
            {
                StatusCode = statusCode,
                Body = JsonSerializer.Serialize(errorBody)
            };
        }

        public static APIGatewayHttpApiV2ProxyResponse HandleUnauthorized()
        {
            return new APIGatewayHttpApiV2ProxyResponse()
            {
                StatusCode = 401,
                Body = JsonSerializer.Serialize(new { Message = "Unauthorized" })
            };
        }

        public static APIGatewayHttpApiV2ProxyResponse HandleException(Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
            Console.WriteLine("EXCEPTION: " + ex.InnerException);
            return new APIGatewayHttpApiV2ProxyResponse()
            {
                StatusCode = 500,
                Body = JsonSerializer.Serialize(new
                {
                    Error = ex.Message,
                    Exception = ex.InnerException
                })
            };
        }
    }
}
