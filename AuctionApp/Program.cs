// <copyright file="Program.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

using AuctionApp.Extensions;
using DomainModel.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<MyConfiguration>(builder.Configuration.GetSection("myConfiguration"));

builder.Services.AddStorage(builder.Configuration);
builder.Services.AddConfiguration();
builder.Services.AddDomainServices();
builder.Services.AddValidators();
builder.Services.AddLogging();

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