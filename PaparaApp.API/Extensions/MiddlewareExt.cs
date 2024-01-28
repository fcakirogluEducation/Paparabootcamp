using Microsoft.AspNetCore.Diagnostics;
using PaparaApp.API.Exceptions;
using PaparaApp.API.Models.Shared;

namespace PaparaApp.API.Extensions

;

public static class MiddlewareExt
{
    public static void AddDefaultMiddlewaresExt(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // http => https
        app.UseHttpsRedirection();


        app.UseStaticFiles();

        app.UseAuthorization();
        app.MapControllers();
    }


    public static void AddExceptionMiddleware(this WebApplication app)
    {
        app.UseExceptionHandler(innerapp =>
        {
            innerapp.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>()?.Error;


                if (exception is null) return;


                var responseDto = ResponseDto<object>.Fail(exception.Message);

                context.Response.StatusCode = exception switch
                {
                    ClientValidationError => 400,
                    _ => 500
                };

                await context.Response.WriteAsJsonAsync(responseDto);
            });
        });
    }
}