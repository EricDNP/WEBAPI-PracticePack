using Domain.Entities;
using Serverless.Handler;
using Amazon.Lambda.APIGatewayEvents;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Payments.SearchPayment;
using Application.UseCases.Payments.ManagePayment;
using Application.UseCases.Payments.RemovePayment;

namespace LMBPaymentCRUD
{
    public static class Handlers
    {
        public static async Task<APIGatewayHttpApiV2ProxyResponse> GET(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<ISearchPaymentUseCase>();
            return await BaseHandler<Payment>.GET(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> POST(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IManagePaymentUseCase>();
            return await BaseHandler<Payment>.POST(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> PUT(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IManagePaymentUseCase>();
            return await BaseHandler<Payment>.PUT(useCase, request);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> DELETE(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IRemovePaymentUseCase>();
            return await BaseHandler<Payment>.DELETE(useCase, request);
        }
    }
}
