namespace TheCardGame.Infrastructure.Interfaces {
    public interface ICardGame {
        public IPlayers? Players { get; set; }
        int InitialDrawCount { get; set; }

        void DoAction();
        void NextPhase();
        void Start();
        void Stop();
    }
}