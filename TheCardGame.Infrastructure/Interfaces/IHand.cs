namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IHand
    {
        IEnumerable<ICard> Cards { get; }

        void AddCard(ICard newCard);
        ICard RemoveCard(ICard card);
        ICard RemoveCard(int v);
    }
}
