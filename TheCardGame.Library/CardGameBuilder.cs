using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public class CardGameBuilder : ICardGameBuilder
    {
        readonly IDeckManager deckMgr;
        bool playerQuit = false;
        private ICardGame _cardGame;        

        public CardGameBuilder(IDeckManager deckManager, ICardGame cardGame){
            deckMgr = deckManager;
            _cardGame = cardGame;
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
            if (_cardGame.Players == null) {
                throw new Exception("Player list is not defined");
            }
            _cardGame.Players.AddPlayer(player);
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

        public ICardGameBuilder InitialCardDrawCount(int drawCount = 5) {
            if (drawCount < 0) {
                throw new Exception("Card Draw count can't be below 0");
            }

            _cardGame.InitialDrawCount = drawCount;
            return this;
        }

        public void AddGamePhases(IGamePhases gamePhases) {
            _cardGame.AddGamePhases(gamePhases);
        }


        public ICardGame Build() => _cardGame;


    }
}
