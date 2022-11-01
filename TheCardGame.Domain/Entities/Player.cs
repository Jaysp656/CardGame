using System.Runtime.CompilerServices;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Domain.Entities
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public double Health { get; set; } = 10;
        public IHand Hand { get; set; }
        public IGameActions Actions { get; set; }
        public IDeck Deck { get; set; }
        public bool CurrentTurn { get; set; } = false;
        public bool Quit { get; set; } = false;      
    }
}