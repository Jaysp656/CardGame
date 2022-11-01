using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Application.Details.Actions {
    public class DiscardCardAction {
        private readonly IPlayer _player;
        private readonly ICard _card;
        private readonly IDeck _discardPile;

        public DiscardCardAction(IPlayer player, ICard card, IDeck discardPile) {
            _player = player;
            _card = card;
            _discardPile = discardPile;
        }

        public DiscardCardAction Create(IPlayer player, ICard card, IDeck discardPile) {
            return new DiscardCardAction(player, card, _discardPile);
        }

        public string Name => "Discard Card";

        public string Description => "Player dicards cards from deck.";

        public void DoAction() {
            _player.Hand.RemoveCard(_card);

            //TODO: should this be List<card>? LIFO instead of FIFO
            _discardPile.Cards.Enqueue(_card);
        }
    }
}
