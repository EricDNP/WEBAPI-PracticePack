using System.Text.Json;
using Serverless.Handler;
using Infrastructure.Configuration;
using Amazon.Lambda.APIGatewayEvents;
using Application.UseCases.Users.LoginUser;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Users.RegisterUser;

namespace LMBUserAuthentication
{
    public static class Handlers
    {
        public static async Task<APIGatewayHttpApiV2ProxyResponse> Login(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<ILoginUserUseCase>();

            var dto = SerializerHandle.Deserialize<LoginUserInput>(request.Body);

            if (dto == null)
                return ErrorHandler.HandleGeneric(new { Message = "Se ingreso un cuerpo invalido." });

            var response = await useCase.Login(dto);

            if (response != null)
            {
                AuthenticationManager.GetUserInfo(response?.Token, provider);

                return new APIGatewayHttpApiV2ProxyResponse()
                {
                    StatusCode = 200,
                    Body = JsonSerializer.Serialize(response)
                };
            }
            else
                return ErrorHandler.HandleGeneric(new { Message = "Usuario no Encontrado" }, 401);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> Register(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IRegisterUserUseCase>();

            var dto = SerializerHandle.Deserialize<RegisterUserInput>(request.Body);

            if (dto == null)
                return ErrorHandler.HandleGeneric(new { Message = "Se ingreso un cuerpo invalido." });

            var response = await useCase.Register(dto);

            return new APIGatewayHttpApiV2ProxyResponse()
            {
                StatusCode = 201,
                Body = JsonSerializer.Serialize(response)
            };
        }
    }
}
