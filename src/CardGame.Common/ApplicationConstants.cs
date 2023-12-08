namespace CardGame.Common;

public static class ApplicationConstants
{
    public const string ZuckerbergDescriptor = "zuck";
    public const string MuskDescriptor = "musk";
    
    public static class MuskRoutesConstants
    {
        public const string SetStrategyRoute = "http://localhost:5127/musk/api/set-strategy";
        public const string MuskQueueRoute = "rabbitmq://localhost/musk";
        public const string GetChoiceRoute = "http://localhost:5127/musk/api/get-answer/";
    }
    
    public static class ZuckerbergRoutesConstants
    {
        public const string SetStrategyRoute = "http://localhost:5159/zuckerberg/api/set-strategy";
        public const string ZuckerbergQueueRoute = "rabbitmq://localhost/zuck";
        public const string GetChoiceRoute = "http://localhost:5159/zuckerberg/api/get-answer/";
    }

    public static class ObserverRoutesConstants
    {
        public const string SetGameResultRote = "http://localhost:5272/card-game/api/observer-room/set-game-result";
    }

    public static class AncientGodsRoutesConstants
    {
        public const string StartGameRoute = "http://localhost:5288/ancient-gods/api/start-game";
        public const string AncientGodsQueueRoute = "rabbitmq://localhost/gods";
    }
}