using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Domain.Entities
{
    public class Player : IPlayer
    {
        public Player() { }

        public string Name { get; set; }
        public double Health { get; set; }
        public IHand Hand { get; set; }
        public IGameActions Actions { get; set; }
        public IDeck Deck { get; set; }
        public bool Quit { get; set; }
    }
}