using System.Text.Json.Serialization;
using ContractWatcher.SDK.AspNetCore.Extensions;
using ContractWatcher.SDK.Configuration.Extensions;
using ContractWatcher.SDK.Configuration.Options;
using ContractWatcher.SDK.Scanning.Enums;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOptions<ContractWatcherOptions>()
    .Bind(builder.Configuration.GetSection("ContractWatcher"));

builder.Services
    .AddContractWatcher()
    .AddDefaults();

builder.Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        // Не возвращать HTTP 400 автоматически при ошибках ModelState.
        options.SuppressModelStateInvalidFilter = true;
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.NumberHandling =
            JsonNumberHandling.Strict;
    })
    .AddContractWatcher()
    .AddContractWatcherScanning(scanning => scanning
        .AddSynchronization(options =>
        {
            options.SourcePreference = ContractSourcePreference.Application;
        })
        .AddPublication());

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();