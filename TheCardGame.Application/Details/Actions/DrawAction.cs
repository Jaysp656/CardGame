using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library;

namespace TheCardGame.Application.Details.Actions {
    public class DrawAction : BaseAction {

        public override void DoAction(ICardGame game) {
            game.Players.DrawCards(1, game.Players.CurrentPlayer);

        }
    }
}
