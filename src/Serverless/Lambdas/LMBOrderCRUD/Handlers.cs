using Domain.Entities;
using Serverless.Handler;
using Amazon.Lambda.APIGatewayEvents;
using Application.UseCases.Orders.ManageOrder;
using Application.UseCases.Orders.RemoveOrder;
using Application.UseCases.Orders.SearchOrder;
using Microsoft.Extensions.DependencyInjection;

namespace LMBOrderCRUD
{
    public static class Handlers
    {
        public static async Task<APIGatewayHttpApiV2ProxyResponse> GET(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<ISearchOrderUseCase>();
            return await BaseHandler<Order>.GET(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> POST(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IManageOrderUseCase>();
            return await BaseHandler<Order>.POST(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> PUT(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IManageOrderUseCase>();
            return await BaseHandler<Order>.PUT(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> DELETE(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IRemoveOrderUseCase>();
            return await BaseHandler<Order>.DELETE(useCase, request);
        }
    }
}
