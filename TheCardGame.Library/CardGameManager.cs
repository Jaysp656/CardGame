using System.Reflection;
using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library
{
    public class CardGameManager : ICardGameManager
    {
        readonly IDeckManager deckMgr;
        Players players = new();
        bool playerQuit = false;

        int StartingDrawCount = 1;

        public CardGameManager(IDeckManager deckManager){
            deckMgr = deckManager;
        }

        public void AddPlayer(IPlayer player, string deckName)
        {
            if (player is null)
            {
                throw new ArgumentNullException(nameof(player));
            }
            if (string.IsNullOrWhiteSpace(deckName))
            {
                throw new ArgumentException($"'{nameof(deckName)}' cannot be null or whitespace.", nameof(deckName));
            }
            if (deckMgr.GetDeck(deckName) is null) {
                Console.WriteLine($"Can not find deck named: {deckName}");
                return;
            }

            
            Console.WriteLine($"Player {player.Name} has entered the game");
            AssignDeck(player, deckName);          
            players.AddPlayer(player);
        }

        public void AssignDeck(IPlayer player, string deckName)
        {
            if (deckMgr.HasDeck(deckName)) {
                player.Deck = deckMgr.GetDeck(deckName);
                Console.WriteLine($"Player {player.Name} has been assigned the {deckMgr.GetDeck(deckName)?.Name} deck.");
            }
            else
                throw new Exception($"Deck \"{deckName}\" not found");
        }

       

        public void StartGame()
        {
            Console.WriteLine("Let the games begin!");

            ShuffleDecks();            
            players.DrawCards(StartingDrawCount);

            //IPlayer currentPlayer = players.;
            //while (!isGameEnded()) {





            //}

        }

        private void ShuffleDecks() {
            foreach (IPlayer player in players.GetPlayers()) {
                ShuffleDeck(player);
            }            
        }
        private void ShuffleDeck(IPlayer player) {
            if (player.Deck != null) {
                deckMgr.Shuffle(player.Deck);
            }
        }


        private bool isGameEnded() {
            //setup rules for game end
            //TODO: setup tie condition?
            if (players.GetPlayers().Where(x => x.Health > 0).Count() == 1) {
                IPlayer winner = players.GetPlayers().Single(x => x.Health > 0);
                Console.WriteLine($"{winner.Name} has won the game!");
                return true;
            }
            if (playerQuit) {
                Console.WriteLine($"A player has quit, the game has ended.");
                return true;
            }

            
            return false;
        }
    }
}
