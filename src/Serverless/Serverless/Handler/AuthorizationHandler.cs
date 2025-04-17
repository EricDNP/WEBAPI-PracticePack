using Application.Models;
using Infrastructure.Configuration;
using Amazon.Lambda.APIGatewayEvents;

namespace Serverless.Handler
{
    public static class AuthorizationHandler
    {
        public static UserAuth? CheckAuthorization(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var headers = new Dictionary<string, string>(request.Headers, StringComparer.OrdinalIgnoreCase);

            if (!headers.TryGetValue("authorization", out var authHeader) && string.IsNullOrWhiteSpace(authHeader))
                throw new UnauthorizedAccessException();

            var user = AuthenticationManager.GetUserInfoFromHeader(authHeader, provider);

            if (user != null)
                return user;
            else
                throw new UnauthorizedAccessException();
        }
    }
}
