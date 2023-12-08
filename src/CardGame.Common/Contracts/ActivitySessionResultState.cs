using JetBrains.Annotations;

namespace CardGame.Common.Contracts;

/// <summary>
/// Модель описывающая результат сесии активности
/// </summary>
[PublicAPI]
public class ActivitySessionResultState
{
    /// <summary>
    /// Идентификатор активности
    /// </summary>
    public Guid ActivitySessionGuid { get; set; }

    /// <summary>
    /// статус сессии активности
    /// </summary>
    public string Status { get; set; } = string.Empty;
    
    /// <summary>
    /// Сообщение для пользователя
    /// </summary>
    public string Message { get; set; } = string.Empty;
    
    /// <summary>
    /// Количество проведенных игр в активности
    /// </summary>
    public int AmountOfGames { get; set; }

    /// <summary>
    /// Количество побед
    /// </summary>
    public int AmountOfWins { get; set; }

    /// <summary>
    /// Процент побед
    /// </summary>
    public string Percentage { get; set; } = string.Empty;

    /// <summary>
    /// Стратегия Илона Маска
    /// </summary>
    public string MuskStrategy{ get; set; } = string.Empty;
    
    /// <summary>
    /// Стратегия Марка Цукерберга
    /// </summary>
    public string ZuckerbergStrategy{ get; set; } = string.Empty;
}