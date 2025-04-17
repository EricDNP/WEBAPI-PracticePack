using System.Text.Json;
using Domain.Interfaces.Common;
using Application.UseCases.Common;
using Amazon.Lambda.APIGatewayEvents;
using Infrastructure.Configuration;

namespace Serverless.Handler
{
    public static class BaseHandler<TEntity> where TEntity : class, IBase
    {
        public static async Task<APIGatewayHttpApiV2ProxyResponse> GET<TOutput>(
            IBaseSearchUseCase<TEntity, TOutput> useCase,
            APIGatewayHttpApiV2ProxyRequest request)
            where TOutput : class
        {
            string body = "";

            if (!request.PathParameters.TryGetValue("id", out string? id))
            {
                var result = await useCase.SearchAll();
                body = JsonSerializer.Serialize(result);
            }
            else
            {
                if (Guid.TryParse(id, out Guid parsedId))
                {
                    var result = await useCase.SearchById(parsedId);
                    body = JsonSerializer.Serialize(result);
                }
                else
                    return ErrorHandler.HandleGeneric(new { Message = "Se ingreso un id invalido." });
            }

            return new APIGatewayHttpApiV2ProxyResponse
            {
                StatusCode = 200,
                Body = body
            };
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> POST<TInput,TOutput>(
            IBaseManageUseCase<TEntity, TInput, TOutput> useCase,
            APIGatewayHttpApiV2ProxyRequest request)
            where TInput : class
            where TOutput : class
        {
            var dto = JsonSerializer.Deserialize<TInput>(request.Body);

            if (dto == null)
                return ErrorHandler.HandleGeneric(new { Message = "Se ingreso un cuerpo invalido." });

            var result = await useCase.Create(dto);

            return new APIGatewayHttpApiV2ProxyResponse
            {
                StatusCode = 201,
                Body = JsonSerializer.Serialize(result)
            };
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> PUT<TInput, TOutput>(
            IBaseManageUseCase<TEntity, TInput, TOutput> useCase,
            APIGatewayHttpApiV2ProxyRequest request)
            where TInput : class
            where TOutput : class
        {
            if (!Guid.TryParse(request.PathParameters["id"], out Guid id))
                return ErrorHandler.HandleGeneric(new { Message = "Se ingreso un id invalido." });

            var dto = JsonSerializer.Deserialize<TInput>(request.Body);

            if (dto == null)
                return ErrorHandler.HandleGeneric(new { Message = "Se ingreso un cuerpo invalido." });

            var result = await useCase.Update(dto, id);

            return new APIGatewayHttpApiV2ProxyResponse
            {
                StatusCode = 200,
                Body = JsonSerializer.Serialize(result)
            };
        }

        public static async Task<APIGatewayHttpApiV2ProxyResponse> DELETE(
            IBaseRemoveUseCase<TEntity> useCase,
            APIGatewayHttpApiV2ProxyRequest request)
        {
            if (!Guid.TryParse(request.PathParameters["id"], out Guid id))
                return ErrorHandler.HandleGeneric(new { Message = "Se ingreso un id invalido." });

            var result = await useCase.Remove(id);

            return new APIGatewayHttpApiV2ProxyResponse
            {
                StatusCode = 204,
                Body = JsonSerializer.Serialize(result)
            };
        }
    }
}
