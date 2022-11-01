using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Application.Details.Actions {
    public class QuitAction : IGameAction {
        private readonly IPlayer _player;

        public QuitAction(IPlayer player) => _player = player;
        public string Name => "Draw Card";

        public string Description => "Player draws card from deck.";

        Func<object[], bool> IGameAction.DoAction => DoAction;

        public bool DoAction(object[] p) {
            _player.Quit = true;
            return true;
        }
    }
}
