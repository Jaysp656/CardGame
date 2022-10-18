using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library;

namespace TheCardGame.Application.Details.Actions {
    public class DrawAction : IGameAction {

        private readonly ICardGame _cardGame;

        public DrawAction(ICardGame cardGame) {
            _cardGame = cardGame;
        }
        public string Name => "Draw Card";

        public string Description => "Player draws card from deck.";

        public void DoAction() {
            _cardGame.Players.DrawCards(1, _cardGame.Players.CurrentPlayer);
        }
    }
}
