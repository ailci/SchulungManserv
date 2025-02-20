using Client.UI.Services;
using Logging;

var builder = WebApplication.CreateBuilder(args);

//Serilog
builder.ConfigLoggingService();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IQotdApiService, QotdApiService>();

//Named Http-Client
builder.Services.AddHttpClient("qotdapiservice", client =>
{
    client.BaseAddress = new Uri("https://localhost:7083/api/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});









var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
