using CardGame.Common;
using CardGame.Common.Messaging.Contracts;
using CardGame.ZuckerbergRoom.Application.Game;
using MassTransit;

namespace CardGame.ZuckerbergRoom.Application.Messaging;

public class SendDeckConsumer : IConsumer<SendDeckModel>
{
    private readonly ZuckerbergRoomService _zuckerbergRoomService;
    
    public SendDeckConsumer(ZuckerbergRoomService zuckerbergRoomService)
    {
        _zuckerbergRoomService = zuckerbergRoomService;
    }

    public async Task Consume(ConsumeContext<SendDeckModel> context)
    {
        var muskEndpoint = await context.GetSendEndpoint(new Uri(ApplicationConstants.AncientGodsRoutesConstants.AncientGodsQueueRoute));
        await muskEndpoint.Send(new PlayerChoiceModel()
        {
            Id = context.Message.Id,
            GameId = context.Message.GameId,
            CardNumber = _zuckerbergRoomService.UseStrategy(context.Message.Stack),
            Descriptor = ApplicationConstants.ZuckerbergDescriptor
        });
    }
    
    
}