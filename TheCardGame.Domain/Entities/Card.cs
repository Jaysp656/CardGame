using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Domain.Entities
{
    public class Card : ICard
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Type { get; set; }

        public IEnumerable<string> Attributes { get; set; }
        public Dictionary<string, string> Properties { get; set; }

        //TODO: Add gameAttributes
    }
}
