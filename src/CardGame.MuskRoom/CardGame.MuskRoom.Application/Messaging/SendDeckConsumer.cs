using CardGame.Common;
using CardGame.Common.Messaging.Contracts;
using CardGame.MuskRoom.Application.Game;
using MassTransit;

namespace CardGame.MuskRoom.Application.Messaging;

public class SendDeckConsumer : IConsumer<SendDeckModel>
{
    private readonly MuskRoomService _muskRoomService;

    public SendDeckConsumer(MuskRoomService muskRoomService)
    {
        _muskRoomService = muskRoomService;
    }

    public async Task Consume(ConsumeContext<SendDeckModel> context)
    {
        var muskEndpoint = await context.GetSendEndpoint(new Uri(ApplicationConstants.AncientGodsRoutesConstants.AncientGodsQueueRoute)); 
        
        await muskEndpoint.Send(new PlayerChoiceModel()
        {
            Id = context.Message.Id,
            GameId = context.Message.GameId,
            CardNumber = _muskRoomService.UseStrategy(context.Message.Stack),
            Descriptor = ApplicationConstants.MuskDescriptor
        });
    }
}