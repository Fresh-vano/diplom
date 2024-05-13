using DataParser.BackgroundService;
using DataParser.Data;
using DataParser.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

builder.Services.AddCors(c =>
{
	c.AddDefaultPolicy(
		policy =>
		{
			policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
		}
	);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

builder.Services.AddScoped<ITeamUpdateService, TeamUpdateService>();
builder.Services.AddScoped<ITournamentUpdateService, TournamentUpdateService>();
builder.Services.AddScoped<IMatchUpdateService, MatchUpdateService>();
builder.Services.AddScoped<TeamIdsResolver>();
builder.Services.AddScoped<CountryIdsResolver>();

builder.Services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();
builder.Services.AddSingleton<IDictionary<string, CancellationTokenSource>>(new Dictionary<string, CancellationTokenSource>());
builder.Services.AddHostedService<Worker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
