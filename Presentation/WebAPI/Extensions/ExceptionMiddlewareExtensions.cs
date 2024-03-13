using Application.Services.Logging;
using Domain.ErrorModels;
using Domain.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace WebAPI.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService loggerService)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>(); // uygulama hatalarını aldık.

                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            BadRequestException => StatusCodes.Status400BadRequest,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        // tam bu anda hatayı loglayalım.
                        loggerService.LogError($"Something went wrong :  {contextFeature.Error}");

                        // client'a döneceğimiz response'u kendi hata modelimiz olan ErrorDetails kullanarak oluşturalım.
                        await context.Response.WriteAsync(new ErrorDetails
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
