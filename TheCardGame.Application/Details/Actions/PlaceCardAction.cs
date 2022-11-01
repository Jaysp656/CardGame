using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library;

namespace TheCardGame.Application.Details.Actions {
    public class PlaceCardAction : IGameAction {

        private readonly IPlayer _player;

        public PlaceCardAction(IPlayer player, ICard card, int position, bool isFaceDown = true, bool isHorizontal = true) {
            _player = player;
        }
        public string Name => "Place Card";

        public string Description => "Player places card from hand onto the board.";

        Func<object[], bool> IGameAction.DoAction => DoAction;

        public bool DoAction(object[] p) {
            //TODO:
            return true;
        }
    }
}
