namespace TheCardGame.Infrastructure.Interfaces
{
    public interface ICardGameBuilder
    {
        ICardGameBuilder AddPlayer(IPlayer player, string deckName);
        ICardGameBuilder AssignDeck(IPlayer player, string deckName);
        ICardGame Build();
        ICardGameBuilder InitialCardDrawCount(int drawCount = 5);
    }
}