using DataMapper.PostgresDAO;
using Microsoft.EntityFrameworkCore;
using ServiceLayer;
using ServiceLayer.ServiceImplementation;
using Microsoft.Extensions.DependencyInjection;
using DataMapper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AuctionAppContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AuctionDatabase") ?? throw new InvalidOperationException("Connection string 'AuctionDatabase' not found."), 
    b => b.MigrationsAssembly("AuctionApp")));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IUserDataServices, PostgresUserDataServices>();




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
