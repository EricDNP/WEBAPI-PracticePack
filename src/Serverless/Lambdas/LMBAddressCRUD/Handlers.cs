using Domain.Entities;
using Serverless.Handler;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Addresses.ManageAddress;
using Application.UseCases.Addresses.RemoveAddress;
using Application.UseCases.Addresses.SearchAddress;

namespace LMBAddressCRUD
{
    public static class Handlers
    {
        public static async Task<APIGatewayHttpApiV2ProxyResponse> GET(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<ISearchAddressUseCase>();
            return await BaseHandler<Address>.GET(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> POST(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IManageAddressUseCase>();
            return await BaseHandler<Address>.POST(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> PUT(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IManageAddressUseCase>();
            return await BaseHandler<Address>.PUT(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> DELETE(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IRemoveAddressUseCase>();
            return await BaseHandler<Address>.DELETE(useCase, request);
        }
    }
}
