using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Domain.Entities
{
    public class DiscardPile : IDeck, IDiscardPile {
        string IDeck.Name { get; set; }
        string IDeck.Description { get; set; }
        Queue<ICard> IDeck.Cards { get; set; }
    }
}
