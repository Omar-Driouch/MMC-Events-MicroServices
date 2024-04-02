using Microsoft.EntityFrameworkCore;
using ParamsService.Infrastructure.Data;
using ParamsService.Infrastructure;
using ParamsService.Application;
using Microsoft.AspNetCore.Builder.Extensions;
using MMCEventsV1.Middlewares;
using ParamsService.API.Services;
using ParamsService.Application.Interfaces;
using ParamsService.Application.Services;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();




builder.Services.AddScoped<IRabbitMQ, RpcClient>();
builder.Services.AddScoped<INotificationsServer, NotificationsServer>();
var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors("AllowAll");
app.MapControllers();
app.UseRouting();
app.Run();
