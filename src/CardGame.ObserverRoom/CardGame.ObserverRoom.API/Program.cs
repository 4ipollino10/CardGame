using CardGame.Common.DependencyInjection;
using CardGame.ObserverRoom.Application;
using CardGame.ObserverRoom.Application.Game;
using CardGame.ObserverRoom.Application.Ports;
using CardGame.ObserverRoom.Core.GameDomain;
using CardGame.ObserverRoom.Core.Ports;
using CardGame.ObserverRoom.Infrastructure.GameDomain;
using CardGame.ObserverRoom.Infrastructure.GameDomain.EntityFramework.Adapters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ObserverRoomService>();
builder.Services.AddScoped<GameContext>();
builder.Services.AddDbContextFactory<GameDbContext>(
    options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("CardGameConnection"))
);
builder.Services.AddDbContext<GameDbContext>(ServiceLifetime.Scoped);
builder.Services.AddScoped<GamesManagementStorage>()
    .As<IGamesManagementStorage>()
    .As<IDatabaseMaintenance>();
builder.Services.AddScoped<ApplicationExecutionContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var isp = scope.ServiceProvider;
    using var context = isp.GetRequiredService<GameDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();