namespace TheCardGame.Infrastructure.Interfaces {
    public interface ICardGame {
        public IPlayers Players { get; set; }        
        int InitialDrawCount { get; set; }

        void AddGamePhases(IGamePhases gamePhases);
        void DoAction();
        void NextPhase();
        void Start();
        void Stop();
    }
}