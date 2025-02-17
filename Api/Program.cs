using Api.Extensions;
using Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureApi();



var app = builder.Build();

//##############################################################
//app.Use(async (context, next) =>
//{
//    var userAgent = context.Request.Headers["User-Agent"][0];
//    await context.Response.WriteAsync($"Erste middleware {userAgent}\n");
//    await next();
//    await context.Response.WriteAsync("Erste middleware Back\n");
//});
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Zweite middleware\n");
//    await next();
//});
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("End middleware\n");
//});
//##############################################################

// Configure the HTTP request pipeline. ################################################
//app.UseBrowserAllowedMiddleware(BrowserType.Chrome, BrowserType.Edge);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
