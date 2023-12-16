using Microsoft.AspNetCore.Diagnostics;
using System.Net;
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
                        ClientSideException => HttpStatusCode.BadRequest,
                        NotFoundException => HttpStatusCode.NotFound,
                        _ => HttpStatusCode.InternalServerError
                    };

                    context.Response.StatusCode = (int)statusCode;

                    var response = exceptionHandler.Error.Message;

                    await context.Response.WriteAsJsonAsync(response);

                });
            });
        }

    }
}
