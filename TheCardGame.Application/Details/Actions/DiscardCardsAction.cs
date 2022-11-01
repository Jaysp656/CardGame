using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Application.Details.Actions {
    public class DiscardCardsAction : IGameAction {
        private readonly IPlayer _player;
        private readonly int _cardCount;
        private readonly IDeck _discardPile;

        public DiscardCardsAction(IPlayer player, int cardCount, IDeck discardPile) {
            _player = player;
            _cardCount = cardCount;
            _discardPile = discardPile;
        }
        public string Name => "Discard Card";
        public string Description => "Player dicards cards from deck.";

        Func<object[], bool> IGameAction.DoAction => DoAction;

        public bool DoAction(object[] p) {
            for (int i = 0; i < _cardCount; i++) {
                if (i > _player.Hand.Cards.Count()) { break; }
                ICard removedCard = _player.Hand.RemoveCard(0);

                //TODO: should this be List<card>? LIFO instead of FIFO
                _discardPile.Cards.Enqueue(removedCard);
            }

            return true;
        }
    }
}
