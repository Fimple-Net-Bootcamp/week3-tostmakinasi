using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using VirtualPetCare.Service.Exceptions;

namespace VirtualPetCare.API.Middlewares
{
    public static class UseCustomExceptionHadler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionHandler = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionHandler.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;

                    var response = exceptionHandler.Error.Message;

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });
        }

    }
}
