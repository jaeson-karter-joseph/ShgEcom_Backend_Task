using ShgEcom.Api;
using ShgEcom.Api.Middlerware;
using ShgEcom.Application;
using ShgEcom.Application.SignalR;
using ShgEcom.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation().AddApplication().AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseMiddleware<RequestResponseLoggingMiddleware>();
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShgEcom API v1");
            c.InjectJavascript("/swagger-ui/signalr-client.js");
        });
    }

    app.UseRateLimiter();
    app.MapHub<NotificationHub>("/notificationHub");
    app.UseExceptionHandler("/error");
    app.UseStaticFiles();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


