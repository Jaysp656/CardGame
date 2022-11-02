namespace TheCardGame.Infrastructure.Interfaces {
    public interface ICardGame {
        int InitialDrawCount { get; set; }
        ICardGameInfo CardGameInfo { get; }

        void AddGamePhases(IGamePhases gamePhases);
        void DoAction(string actionName, int playerId, int DeckId);
        void GetPlayerActions(int playerId);
        void NextPhase();
        void Start();
        void Stop();
    }
}