using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Domain.Entities
{
    public class Hand : IHand
    {
        private List<ICard> _cards = new List<ICard>();

        public IEnumerable<ICard> Cards => _cards;

        public void AddCard(ICard newCard)
        {
            (_cards as List<ICard>).Add(newCard);
        }

        public void RemoveCard(ICard card)
        {
            (_cards as List<ICard>).Remove(card);
        }
    }
}