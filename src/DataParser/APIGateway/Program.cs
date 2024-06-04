using Microsoft.Extensions.DependencyInjection;
using Ocelot.Cache;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot().AddCacheManager(x =>
{
	x.WithDictionaryHandle();
});

builder.Services.AddPrometheusHttpClientMetrics();
builder.Services.AddPrometheusCounters();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use Prometheus metrics
app.UseHttpMetrics();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Use Ocelot middleware
app.UseOcelot().Wait();

// Map Prometheus metrics endpoint
app.UseEndpoints(endpoints =>
{
	endpoints.MapMetrics();
});

app.Run();
