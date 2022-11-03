using System.ComponentModel;

namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IGamePlayerAction
    {
        public bool isCurrentPlayerAction { get; set; }
    }
}