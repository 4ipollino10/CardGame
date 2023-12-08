using JetBrains.Annotations;

namespace CardGame.Common.Contracts;

/// <summary>
/// Модель конфигурации серии игр
/// </summary>
[PublicAPI]
public class GameConfigurationModel
{
    /// <summary>
    /// Стратегия игры для Илона Маска
    /// </summary>
    public string? MuskGameStrategy { get; set; }

    /// <summary>
    /// Стратегия игры для Марка Цукерберга
    /// </summary>
    public string? ZuckerbergGameStrategy { get; set; }

    /// <summary>
    /// Количество проводимых игр
    /// </summary>
    public int AmountOfGames { get; set; }
}