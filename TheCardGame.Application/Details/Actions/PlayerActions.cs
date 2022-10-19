using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Application.Details.Actions {
    public class PlayerActions {

        private static readonly PlayerActions instance = new();
        public static PlayerActions Instance => instance;

        public static void Draw(IPlayer player, IDeck deck, int drawCount = 1) {
            //TODO set validation rules here...
            for (int i = 0; i < drawCount; i++) {
                var card = deck.Cards.Dequeue();
                player.Hand.AddCard(card);
            }           
        }

        public static void PlaceCard(IPlayer player, ICard card, int position, bool isFaceDown = true, bool isHorizontal = true) {
            //TODO: interact with board. Remove from player's hand and add to board at position;
        }

        /// <summary>
        /// View top card of deck
        /// </summary>
        /// <param name="player"></param>
        /// <param name="deck"></param>
        /// <returns></returns>
        public static ICard PeekDeck(IPlayer player, IDeck deck) {
            return deck.Cards.Peek();
        }

        public static void DiscardCardFromHand(IPlayer player, ICard card, IDeck discardPile) { 
            player.Hand.RemoveCard(card);

            //TODO: should this be List<card>? LIFO instead of FIFO
            discardPile.Cards.Enqueue(card);
        }

        public static void EndTurn(IPlayer player) { 
            //how to initiate this action?
        }

        public static void Quit(IPlayer player) {
           player.Quit = true;
        }


    }
}
