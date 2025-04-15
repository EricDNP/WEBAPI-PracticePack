using System.Text.Json;
using Application.Models;
using Infrastructure.Configuration;
using Amazon.Lambda.APIGatewayEvents;

namespace Serverless.Handler
{
    public static class AuthorizationHandler
    {
        public static UserAuth? GetUserInfo(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            if (!request.Headers.TryGetValue("Authorization", out var authHeader) || string.IsNullOrWhiteSpace(authHeader))
                return null;

            Console.WriteLine("Authorization: " + authHeader);

            return AuthenticationManager.GetUserInfoFromHeader(authHeader, provider);
        }

        public static APIGatewayHttpApiV2ProxyResponse Unauthorized()
        {
            return new APIGatewayHttpApiV2ProxyResponse()
            {
                StatusCode = 401,
                Body = JsonSerializer.Serialize(new { Message = "Unauthorized" })
            };
        }
    }
}
