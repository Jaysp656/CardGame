namespace TheCardGame.Infrastructure.Interfaces
{
    public interface ICardGameBuilder
    {
        void AddGamePhases(IGamePhases gamePhases);
        ICardGameBuilder AddPlayer(IPlayer player, string deckName);
        ICardGameBuilder AssignDeck(IPlayer player, string deckName);
        ICardGame Build();
    }
}