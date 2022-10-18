using System.ComponentModel;

namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IGameAction
    {
        public string Name { get; }
        public string Description { get; }
        //Func<bool> action { get; }
        public abstract void DoAction(ICardGame game);
    }
}