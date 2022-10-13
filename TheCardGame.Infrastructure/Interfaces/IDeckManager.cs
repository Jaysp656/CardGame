namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IDeckManager {
        IDeck GetDeck(string deckName);
        IEnumerable<IDeck> GetDecks();
        bool HasDeck(string deckName);
        void Shuffle(IDeck deck);
    }
}
