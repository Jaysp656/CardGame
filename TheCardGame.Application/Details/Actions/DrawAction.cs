using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Application.Details.Actions {
    public class DrawAction : IGameAction{
        public string Name => "Draw Card";
        public string Description => "Player draws card from deck.";

        Func<object[], bool> IGameAction.DoAction => Action;

        private bool Action(params object[] p ) {
            //IPlayer player, IDeck deck, int drawCount
            (IPlayer player, IDeck deck, int drawCount) = ParseParams(p);

            for (int i = 0; i < drawCount; i++) {
                var card = deck.Cards.Dequeue();
                player.Hand.AddCard(card);
            }
            return true;
        }

        private (IPlayer, IDeck, int) ParseParams(params object[] p) {
            if (p[0] is not IPlayer || p[1] is not IDeck || p[2] is not int) { throw new Exception("Action parameters aren't expected types"); }
            return ((IPlayer)p[0], (IDeck)p[1], (int)p[2]);
        }
    }
}
