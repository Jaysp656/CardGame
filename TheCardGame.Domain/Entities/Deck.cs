using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Domain.Entities
{
    public class Deck : IDeck
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Queue<ICard> Cards { get; set; }
    }
}
