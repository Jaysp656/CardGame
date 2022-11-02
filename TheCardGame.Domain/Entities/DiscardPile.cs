using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Domain.Entities
{
    public class DiscardPile : IDeck, IDiscardPile {
        public int? Id { get; set; }
        string IDeck.Name { get; set; }
        string IDeck.Description { get; set; }
        Queue<ICard> IDeck.Cards { get; set; }
    }
}
