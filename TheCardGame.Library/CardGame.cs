using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public class CardGame : ICardGame {
        public IPlayers Players { get; set; }
        int ICardGame.InitialDrawCount { get; set; }

        public int InitialDrawCount = 0;
        private IDeckManager _deckManager;
        private GamePhases _gamePhases = new();

        public CardGame(IPlayers _players, IDeckManager deckMgr) {
            Players = _players;
            _deckManager = deckMgr;
        }

        public void Start() {
            if (Players == null) { throw new Exception("Players has not been initialized"); }
            Console.WriteLine("Let the games begin!");
            //IPlayer currentPlayer = players.;
            //while (!isGameEnded()) {
            //}
            
            NextPhase();
        }

        public void AddPlayers(IPlayers players) { 
            Players = players;
        }

        public void AddDeckManager(IDeckManager deckMgr) {
            _deckManager = deckMgr;
        }

        public void DoAction() { }

        public void NextPhase() {
            _gamePhases.SetNextPhase();
            Players.CurrentPlayer.Actions = _gamePhases.CurrentPhase.GetPlayerActions(true);
        }

        public void Stop() {
            Console.WriteLine("Game has ended");
        }


        public void AddGamePhases(IGamePhases gamePhases) {
            _gamePhases = (GamePhases)gamePhases;
        }

        private bool isGameEnded() {
            //setup rules for game end
            //TODO: setup tie condition?
            if (Players == null) { throw new Exception("No players exist when checking if game is ended"); }

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