namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IHand
    {
        IEnumerable<ICard> Cards { get; }

        void AddCard(ICard newCard);
        void RemoveCard(ICard card);
    }
}
