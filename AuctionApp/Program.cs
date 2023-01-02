using DataMapper.PostgresDAO;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;
using ServiceLayer.ServiceImplementation;
using Microsoft.Extensions.DependencyInjection;
using DataMapper;
using AuctionApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStorage(builder.Configuration);
builder.Services.AddConfiguration();
builder.Services.AddDomainServices();
builder.Services.AddValidators();
// Add services to the container.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
