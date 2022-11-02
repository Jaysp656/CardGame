using System.ComponentModel;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Domain.Entities
{
    public class Decks
    {
        private List<IDeck> _decks { get; set; }

        public int Add(IDeck newDeck) {
            _decks.Add(newDeck);
            return _decks.IndexOf(newDeck);
        }

        public void Remove(int deckId) {
            IDeck deck = _decks.SingleOrDefault(x => x.Id == deckId);
            if (deck != null) {
                _decks.Remove(deck);
            }
        }

        public void Clear() {
            _decks.Clear();
        }

        public bool Contains(IDeck newDeck) {
            return _decks.Contains(newDeck);
        }

        public IDeck GetDeck(int deckId) {
            try {
                return _decks.SingleOrDefault(x => x.Id == deckId);
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
