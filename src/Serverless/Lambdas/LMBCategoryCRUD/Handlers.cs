using Domain.Entities;
using Serverless.Handler;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Categories.ManageCategory;
using Application.UseCases.Categories.RemoveCategory;
using Application.UseCases.Categories.SearchCategory;

namespace LMBCategoryCRUD
{
    public static class Handlers
    {
        public static async Task<APIGatewayHttpApiV2ProxyResponse> GET(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<ISearchCategoryUseCase>();
            return await BaseHandler<Category>.GET(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> POST(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IManageCategoryUseCase>();
            return await BaseHandler<Category>.POST(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> PUT(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IManageCategoryUseCase>();
            return await BaseHandler<Category>.PUT(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> DELETE(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IRemoveCategoryUseCase>();
            return await BaseHandler<Category>.DELETE(useCase, request);
        }
    }
}
