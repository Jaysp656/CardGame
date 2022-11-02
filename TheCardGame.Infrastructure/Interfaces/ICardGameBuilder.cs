namespace TheCardGame.Infrastructure.Interfaces
{
    public interface ICardGameBuilder
    {
        void AddGamePhases(IGamePhases gamePhases);
        ICardGameBuilder AddPlayer(IPlayer player, int deckId);
        ICardGameBuilder AssignDeck(IPlayer player, int deckId);
        ICardGame Build();
    }
}