using CardGame.AncientGods.Application;
using CardGame.AncientGods.Application.Game;
using CardGame.AncientGods.Application.Game.Deck;
using CardGame.AncientGods.Application.Messaging;
using CardGame.AncientGods.Application.Ports;
using CardGame.AncientGods.Core.Adapters;
using CardGame.AncientGods.Core.GameDomain;
using CardGame.AncientGods.Infrastructure.GameDomain;
using CardGame.AncientGods.Infrastructure.GameDomain.EntityFramework.Adapters;
using CardGame.Common.DependencyInjection;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<DeckManipulatorService>();
builder.Services.AddScoped<AncientGodsService>();
builder.Services.AddScoped<SendDeckPublisher>();
builder.Services.AddDbContextFactory<GameDbContext>(
    options =>
        options.UseNpgsql("Server=localhost;Port=5432;Database=game;User Id=postgres;Password=1;")
);
builder.Services.AddDbContext<GameDbContext>(ServiceLifetime.Scoped);
builder.Services.AddScoped<GameContext>();
builder.Services.AddScoped<GameStorage>()
    .As<IGameStorage>()
    .As<IDatabaseMaintenance>();
builder.Services.AddScoped<ApplicationExecutionContext>();
builder.Services.AddScoped<GameService>();

builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.AddConsumer<PlayerChoiceConsumer>()
        .Endpoint(e => e.Name = "gods");
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var isp = scope.ServiceProvider;
    using var context = isp.GetRequiredService<GameDbContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();