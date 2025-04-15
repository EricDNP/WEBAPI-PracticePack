using Domain.Entities;
using System.Text.Json;
using Serverless.Handler;
using Amazon.Lambda.APIGatewayEvents;
using Application.UseCases.Users.LoginUser;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Configuration;
using Application.UseCases.Users.RegisterUser;

namespace LMBUserAuthentication
{
    public static class Handlers
    {
        public static async Task<APIGatewayHttpApiV2ProxyResponse> Login(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<ILoginUserUseCase>();

            var dto = JsonSerializer.Deserialize<LoginUserInput>(request.Body);

            if (dto == null)
                return BaseHandler<User>.ERROR(new { Message = "Se ingreso un cuerpo invalido." });

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
                return BaseHandler<User>.ERROR(new { Message = "Usuario no Encontrado" }, 401);
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> Register(APIGatewayHttpApiV2ProxyRequest request, IServiceProvider provider)
        {
            var useCase = provider.GetRequiredService<IRegisterUserUseCase>();

            var dto = JsonSerializer.Deserialize<RegisterUserInput>(request.Body);

            if (dto == null)
                return BaseHandler<User>.ERROR(new { Message = "Se ingreso un cuerpo invalido." });

            var response = await useCase.Register(dto);

            return new APIGatewayHttpApiV2ProxyResponse()
            {
                StatusCode = 201,
                Body = JsonSerializer.Serialize(response)
            };
        }
    }
}
