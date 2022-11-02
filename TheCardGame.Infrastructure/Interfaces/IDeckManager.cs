namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IDeckManager {
        IDeck GetDeck(int deckId);
        IEnumerable<IDeck> GetDecks();
        bool HasDeck(string deckName);
        bool HasDeck(int deckId);
        void Shuffle(IDeck deck);
    }
}
