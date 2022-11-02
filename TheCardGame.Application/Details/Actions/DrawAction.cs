using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Application.Details.Actions {
    public class DrawAction : IGameAction{
        public string Name => "Draw Card";
        public string Description => "Player draws card from deck.";

        Func<object[], bool> IGameAction.DoAction => Action;

        private bool Action(params object[] p ) {
            //IPlayer player, IDeck deck, int drawCount
            (IPlayer player, IDeck deck) = ParseParams(p);

            //for (int i = 0; i < drawCount; i++) {
                var card = deck.Cards.Dequeue();
                player.Hand.AddCard(card);
            //}
            return true;
        }

        private (IPlayer, IDeck) ParseParams(params object[] p) {
            if (p[0] is not ICardGameInfo || p[1] is not int) { throw new Exception("Action parameters aren't expected types"); }
            ICardGameInfo cardGameInfo = (ICardGameInfo)p[0];

            IPlayer player = cardGameInfo.Players.GetPlayers().SingleOrDefault(x => x.Id == (int)p[1]);
            IDeck deck = cardGameInfo.DeckManager.GetDeck((int)player.DeckId);

            return (player, deck);
        }
    }
}
