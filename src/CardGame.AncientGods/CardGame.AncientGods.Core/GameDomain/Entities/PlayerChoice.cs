using CardGame.Common.Messaging.Contracts;
using JetBrains.Annotations;

namespace CardGame.AncientGods.Core.GameDomain.Entities;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class PlayerChoice
{
    /// <summary>
    /// Конструктор для EF
    /// </summary>
    private PlayerChoice()
    {
        
    }

    public PlayerChoice(PlayerChoiceModel model)
    {
        Id = model.Id;
        GameId = model.GameId;
        Descriptor = model.Descriptor;
        PlayerChoiceCardNum = model.CardNumber;
    }
    
    /// <summary>
    /// Идентификатор сообщения
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Идентификатор игры
    /// </summary>
    public Guid GameId { get; private set; }

    /// <summary>
    /// От кого пришло сообщение
    /// </summary>
    public string Descriptor { get; private set; } = null!;

    /// <summary>
    /// Выбор игрока
    /// </summary>
    public int PlayerChoiceCardNum { get; private set; }
    
}