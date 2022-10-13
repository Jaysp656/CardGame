using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public class CardGame : ICardGame {
        public IPlayers? Players { get; set; }
        int ICardGame.InitialDrawCount { get; set; }

        public int InitialDrawCount = 0;
        private readonly IDeckManager _deckManager;
        private GamePhases _gamePhases;


        public CardGame(IDeckManager deckMgr, IPlayers players) {
            Players = players ?? throw new ArgumentNullException(nameof(players));
            _deckManager = deckMgr ?? throw new ArgumentNullException(nameof(deckMgr));
        }

        public void Start() {
            if (Players == null) { throw new Exception("Players has not been initialized"); }
            Console.WriteLine("Let the games begin!");

            Players.ShuffleDecks();
            Players.DrawCards(InitialDrawCount);

            //IPlayer currentPlayer = players.;
            //while (!isGameEnded()) {
            //}
        }

        public void DoAction() { }

        public void NextPhase() { }

        public void Stop() {
            Console.WriteLine("Game has ended");
        }

        


        private bool isGameEnded() {
            //setup rules for game end
            //TODO: setup tie condition?
            if (Players.GetPlayers().Where(x => x.Health > 0).Count() == 1) {
                IPlayer winner = Players.GetPlayers().Single(x => x.Health > 0);
                Console.WriteLine($"{winner.Name} has won the game!");
                return true;
            }
            if (Players.GetPlayers().Where(x => !x.Quit).Count() == 1 ) {
                Console.WriteLine($"Only one player remaining, the game has ended.");
                return true;
            }


            return false;
        }
    }
}