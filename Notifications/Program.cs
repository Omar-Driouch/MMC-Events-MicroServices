
using Notifications;
using Notifications.Services.EventToNotification;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificDomain",
        builder =>
        {
            builder
            .WithOrigins("https://localhost:7047")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});
builder.Services.AddControllers();


builder.Services.AddScoped<IRabbitMQ, RpcClient>();
builder.Services.AddSingleton(new RecieveNotificationServer(""));

builder.Services.AddScoped<IEventToNotification, EventToNotification>();
var app = builder.Build();

 

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowSpecificDomain");
app.MapControllers();

app.Run();
