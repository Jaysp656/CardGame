using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library;

namespace TheCardGame.Application.Details.Actions {
    public class PeekAction : IGameAction {

        private readonly IPlayer _player;
        private readonly IDeck _deck;
        private readonly int _drawCount;

        public PeekAction(IPlayer player, IDeck deck, int drawCount) {
            _player = player;
            _deck = deck;
            _drawCount = drawCount;
        }
        public string Name => "Peek Card";

        public string Description => "Player looks at card on top of deck.";

        Func<object[], bool> IGameAction.DoAction => DoAction;

        public bool DoAction(object[] p) {
            // How to view n number of items in discarded deck?
            //return _deck.Cards.Peek();
            return true;
        }
    }
}
