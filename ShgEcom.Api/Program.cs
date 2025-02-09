using ShgEcom.Api;
using ShgEcom.Application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation().AddApplication();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


