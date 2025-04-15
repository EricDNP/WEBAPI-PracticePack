using Domain.Entities;
using Serverless.Handler;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.OrderItems.ManageOrderItem;
using Application.UseCases.OrderItems.RemoveOrderItem;
using Application.UseCases.OrderItems.SearchOrderItem;

namespace LMBOrderItemCRUD
{
    public static class Handlers
    {
        public static async Task<APIGatewayHttpApiV2ProxyResponse> GET(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<ISearchOrderItemUseCase>();
            return await BaseHandler<OrderItem>.GET(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> POST(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IManageOrderItemUseCase>();
            return await BaseHandler<OrderItem>.POST(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> PUT(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IManageOrderItemUseCase>();
            return await BaseHandler<OrderItem>.PUT(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> DELETE(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IRemoveOrderItemUseCase>();
            return await BaseHandler<OrderItem>.DELETE(useCase, request);
        }
    }
}
