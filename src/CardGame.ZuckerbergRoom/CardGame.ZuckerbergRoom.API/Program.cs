using CardGame.Strategies.Services;
using CardGame.ZuckerbergRoom.Application.Game;
using CardGame.ZuckerbergRoom.Application.Messaging;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ZuckerbergRoomService>();
builder.Services.AddSingleton<IStrategyProvider, StrategyProvider>();

builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();
    x.AddConsumer<SendDeckConsumer>()
        .Endpoint(e => e.Name = "zuck");
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();