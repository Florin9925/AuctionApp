using AuctionApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

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
