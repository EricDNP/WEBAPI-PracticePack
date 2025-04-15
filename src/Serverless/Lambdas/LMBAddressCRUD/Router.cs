using Domain.Entities;
using Serverless.Handler;
using Amazon.Lambda.Core;
using Serverless.Configuration;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LMBAddressCRUD;

public class Router
{
    private readonly IServiceProvider _provider;

    public Router()
    {
        _provider = DI.Configure();
    }

    public async Task<APIGatewayHttpApiV2ProxyResponse> FunctionHandler(APIGatewayHttpApiV2ProxyRequest request)
    {
        if (AuthorizationHandler.GetUserInfo(request, _provider) == null)
            return AuthorizationHandler.Unauthorized();

        return await RouteAsync(request);
    }

    private async Task<APIGatewayHttpApiV2ProxyResponse> RouteAsync(APIGatewayHttpApiV2ProxyRequest request)
    {
        var method = request.RequestContext?.Http?.Method;

        if (method != null)
        {
            switch (method.ToUpper())
            {
                case "GET":
                    return await Handlers.GET(request, _provider);

                case "POST":
                    return await Handlers.POST(request, _provider);

                case "PUT":
                    return await Handlers.PUT(request, _provider);

                case "DELETE":
                    return await Handlers.DELETE(request, _provider);

                default:
                    return BaseHandler<Payment>.ERROR(new { Message = "Metodo Invalido" });
            }
        }
        else
        {
            return BaseHandler<Payment>.ERROR(new { Message = "Metodo Invalido" });
        }
    }
}
