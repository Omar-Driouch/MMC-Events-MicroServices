using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using AuthService.Infrastracture;
using AuthService.Infrastracture.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.InfrastractureServices(builder.Configuration);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);
     

var app = builder.Build();


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();



app.MapControllers();

await app.UseOcelot();

app.Run();