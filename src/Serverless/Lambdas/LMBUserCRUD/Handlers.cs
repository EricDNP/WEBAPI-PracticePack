using Domain.Entities;
using Serverless.Handler;
using Amazon.Lambda.APIGatewayEvents;
using Application.UseCases.Users.ManageUser;
using Application.UseCases.Users.RemoveUser;
using Application.UseCases.Users.SearchUser;
using Microsoft.Extensions.DependencyInjection;

namespace LMBUserCRUD
{
    public static class Handlers
    {
        public static async Task<APIGatewayHttpApiV2ProxyResponse> GET(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<ISearchUserUseCase>();
            return await BaseHandler<User>.GET(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> DELETE(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IRemoveUserUseCase>();
            return await BaseHandler<User>.DELETE(useCase, request);
        }
    }
}
