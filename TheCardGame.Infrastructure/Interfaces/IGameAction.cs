using System.ComponentModel;

namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IGameAction
    {
        public string Name { get; }
        public string Description { get; }
        public Func<object[], bool> DoAction { get; }
    }
}