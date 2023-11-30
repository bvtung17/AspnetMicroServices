using Discount.API.Extensions;
using Discount.API.Repositories;
using Discount.Grpc.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddGrpc();
builder.Services.AddAutoMapper(typeof(Program));

builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 5002, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
    });
    options.Listen(IPAddress.Any, 4002, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MigrateDatabase<Program>();
app.MapGrpcService<DiscountService>();
app.UseAuthorization();

app.MapControllers();

app.Run();
