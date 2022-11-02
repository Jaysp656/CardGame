using TheCardGame.Domain;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public class CardGameBuilder : ICardGameBuilder
    {
        private readonly ICardGameInfo? _cardGameInfo;
        private readonly IGamePhases? _gamePhases;

        public CardGameBuilder(IGamePhases gamePhases, IDeckManager deckManager, IPlayers player) {
            _cardGameInfo = new CardGameInfo();
            _cardGameInfo.Players = player ?? throw new ArgumentNullException(nameof(player));
            _cardGameInfo.DeckManager = deckManager ?? throw new ArgumentNullException(nameof(deckManager));
            _cardGameInfo.Phases = gamePhases ?? throw new ArgumentNullException(nameof(gamePhases));
        }

        public ICardGameBuilder AddPlayer(IPlayer player, int deckId) {
            if (player is null) {
                throw new ArgumentNullException(nameof(player));
            }
            if (deckId == 0) {
                throw new ArgumentNullException(nameof(deckId));
            }
            if (_cardGameInfo.DeckManager.GetDeck(deckId) is null) {
                Console.WriteLine($"Can not find deck of ID: {deckId}");
                return this;
            }


            Console.WriteLine($"Player {player.Name} has entered the game");
            AssignDeck(player, deckId);
            if (_cardGameInfo.Players == null) {
                throw new Exception("Player list is not defined");
            }
            _cardGameInfo.Players.AddPlayer(player);
            return this;
        }

        public ICardGameBuilder AssignDeck(IPlayer player, int deckId) {
            if (_cardGameInfo.DeckManager.HasDeck(deckId)) {
                player.DeckId = deckId;
                Console.WriteLine($"Player {player.Name} has been assigned the {_cardGameInfo.DeckManager.GetDeck(deckId)?.Name} deck.");
            }
            else
                throw new Exception($"Deck \"{deckId}\" not found");
            return this;
        }

        public void AddGamePhases(IGamePhases gamePhases) {
            _cardGameInfo.Phases =  gamePhases;
        }


        public ICardGame Build() => new CardGame(_cardGameInfo);


    }
}
