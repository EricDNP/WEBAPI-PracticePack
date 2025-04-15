using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Domain.Entities;
using Serverless.Configuration;
using Serverless.Handler;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace LMBUserAuthentication;

public class Router
{
    private readonly IServiceProvider _provider;

    public Router()
    {
        _provider = DI.Configure();
    }

    public async Task<APIGatewayHttpApiV2ProxyResponse> FunctionHandler(APIGatewayHttpApiV2ProxyRequest request)
    {
        return await RouteAsync(request);
    }

    private async Task<APIGatewayHttpApiV2ProxyResponse> RouteAsync(APIGatewayHttpApiV2ProxyRequest request)
    {
        var method = request.RequestContext?.Http?.Method;
        var path = request.RawPath?.ToLowerInvariant().TrimEnd('/');

        return (method?.ToUpper(), path) switch
        {
            ("POST", "/users/login") => await Handlers.Login(request, _provider),
            ("POST", "/users/register") => await Handlers.Register(request, _provider),

            _ => BaseHandler<Payment>.ERROR(new { Message = "Metodo o Request Invalida" })
        };
    }
}
