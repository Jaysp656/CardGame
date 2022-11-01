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

        public ICard RemoveCard(ICard card){
            try {
                (_cards as List<ICard>).Remove(card);
                return card;
            }
            catch(Exception) { 
                throw;
            }            
        }
        public ICard RemoveCard(int cardRemoveIndex) {
            try {
                ICard removedCard = _cards.ElementAtOrDefault(cardRemoveIndex);
                _cards.RemoveAt(cardRemoveIndex);
                return removedCard;
            }
            catch(Exception) { 
                throw;
            }   
        }

        public IEnumerable<ICard> RemoveCards(int cardRemoveCount) {
            try {
                if(_cards.Count < cardRemoveCount) { return new List<ICard>(); }

                IEnumerable<ICard> removedCards = _cards.Take(cardRemoveCount);
                _cards.RemoveRange(0, cardRemoveCount);
                return removedCards;
            }
            catch(Exception) { 
                throw;
            }    
        }
    }
}