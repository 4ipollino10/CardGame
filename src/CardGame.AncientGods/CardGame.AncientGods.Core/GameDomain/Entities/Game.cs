using JetBrains.Annotations;

namespace CardGame.AncientGods.Core.GameDomain.Entities;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class Game
{
    /// <summary>
    /// Конструктор для EF
    /// </summary>
    private Game()
    {
        
    }

    public Game(Guid id, string deck)
    {
        Id = id;
        Deck = deck;
    }

    /// <summary>
    /// Идентификатор игры
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Колода игры
    /// </summary>
    public string Deck { get; private set; } = null!;
}