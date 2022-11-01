using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public class CardGameBuilder : ICardGameBuilder
    {
        readonly IPlayers _players;
        readonly IDeckManager deckMgr;
        private IGamePhases _gamePhases;

        public CardGameBuilder(Players players, IDeckManager deckManager) {
            _players = players;
            deckMgr = deckManager;
        }

        public ICardGameBuilder AddPlayer(IPlayer player, string deckName)
        {
            if (player is null) {
                throw new ArgumentNullException(nameof(player));
            }
            if (string.IsNullOrWhiteSpace(deckName)) {
                throw new ArgumentException($"'{nameof(deckName)}' cannot be null or whitespace.", nameof(deckName));
            }
            if (deckMgr.GetDeck(deckName) is null) {
                Console.WriteLine($"Can not find deck named: {deckName}");
                return this;
            }

            
            Console.WriteLine($"Player {player.Name} has entered the game");
            AssignDeck(player, deckName);
            if (_players == null) {
                throw new Exception("Player list is not defined");
            }
            _players.AddPlayer(player);
            return this;
        }

        public ICardGameBuilder AssignDeck(IPlayer player, string deckName)
        {
            if (deckMgr.HasDeck(deckName)) {
                player.Deck = deckMgr.GetDeck(deckName);
                Console.WriteLine($"Player {player.Name} has been assigned the {deckMgr.GetDeck(deckName)?.Name} deck.");
            }
            else
                throw new Exception($"Deck \"{deckName}\" not found");

            return this;
        }

        public void AddGamePhases(IGamePhases gamePhases) {
            _gamePhases =  gamePhases;
        }


        public ICardGame Build() => new CardGame(_players, deckMgr);


    }
}
