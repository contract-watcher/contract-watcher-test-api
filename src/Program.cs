using ContractWatcher.SDK.AspNetCore.Extensions;
using ContractWatcher.SDK.Configuration.Extensions;
using ContractWatcher.SDK.Configuration.Options;
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
    .AddContractWatcher();

builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();