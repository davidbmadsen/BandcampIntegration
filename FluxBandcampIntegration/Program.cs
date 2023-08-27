using FluxBandcampIntegration.Clients;
using FluxBandcampIntegration.Services;
using FluxBandcampIntegration.Utils;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Memory cache for tokens etc.
var cache = new MemoryCache(new MemoryCacheOptions());

var bandcampClient = new BandcampClient(Utils.CreateMapper());

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(bandcampClient);

builder.Services.AddSingleton(new AuthorizationService(
    builder.Configuration,
    cache,
    bandcampClient));

builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();