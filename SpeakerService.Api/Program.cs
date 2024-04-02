using Microsoft.EntityFrameworkCore;
using SpeakerService.Api;
using SpeakerService.API.Services;
using SpeakerService.Application.Interfaces;
using SpeakerService.Application.Services;
using SpeakerService.Domain.IRepositories;
using SpeakerService.Infrastructure.Data;
using SpeakerService.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SpeakerDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("con")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ISpeakerService, SpeakerServicee>();
builder.Services.AddScoped<IEventSpeakersRepository, EventSpeakersRepository>();
builder.Services.AddScoped<IEventSpeakerServices, EventSpeakerServices>();

builder.Services.AddScoped<ISpeakerRepository, SpeakerRepository>();

//builder.Services.InfrastractureServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .AllowAnyOrigin();
    });
});

var SpeakrEvent = builder.Services.BuildServiceProvider().GetService<IEventSpeakerServices>();

builder.Services.AddSingleton<RabbitMQServer>(new RabbitMQServer(SpeakrEvent));

builder.Services.AddScoped<ISpeakerRequestBroker, SpeakerRequestBroker>();
var app = builder.Build();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
