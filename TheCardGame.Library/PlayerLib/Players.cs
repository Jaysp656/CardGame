using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library.PlayerLib {
    public class Players : IPlayers {
        private List<IPlayer> _players = new();

        public IPlayer CurrentPlayer { get; private set; }

        public Players() { }

        public void AddPlayer(IPlayer player) {
            if (player == null) throw new ArgumentNullException(nameof(player));
            player.Id = _players.Count + 1; //TODO: get this from DB table?
            _players.Add(player);

            if (player.CurrentTurn) {
                CurrentPlayer ??= player;
            }
        }

        public void RemovePlayer(IPlayer player) {
            if (_players.Contains(player)) {
                _players.Remove(player);
            }
        }
        public List<IPlayer> GetPlayers() {
            return _players;
        }
        public void Clear() {
            _players.Clear();
        }
    }
}