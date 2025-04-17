using Serverless.Helper;
using Serverless.Handler;
using Amazon.Lambda.Core;
using Serverless.Configuration;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LMBUserCRUD;

public class Router
{
    private readonly IServiceProvider _provider;

    public Router()
    {
        _provider = DI.Configure();
    }

    public async Task<APIGatewayHttpApiV2ProxyResponse> FunctionHandler(APIGatewayHttpApiV2ProxyRequest request)
    {
        return await FunctionHandlerHelper.HandleFunction(async () =>
        {
            var user = AuthorizationHandler.CheckAuthorization(request, _provider);
            return await RouteAsync(request);
        });
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

                case "DELETE":
                    return await Handlers.DELETE(request, _provider);

                default:
                    return ErrorHandler.HandleGeneric(new { Message = "Metodo Invalido" });
            }
        }
        else
        {
            return ErrorHandler.HandleGeneric(new { Message = "Metodo Invalido" });
        }
    }
}
