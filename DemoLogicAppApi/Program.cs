using DemoAngularCrudApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AngCustDBContext>(options =>
    options.UseInMemoryDatabase("SmartAirDB"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("SmartCors", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("SmartCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();