namespace TheCardGame.Infrastructure.Interfaces
{
    public interface ICardGameManager
    {
        void AssignDeck(IPlayer player, string deckName);
        void AddPlayer(IPlayer player, string deckName);
        void StartGame();
    }
}