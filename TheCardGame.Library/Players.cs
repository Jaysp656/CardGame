using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public class Players {
        private List<IPlayer> _players = new();

        public Players() {}

        public void AddPlayer(IPlayer player) {
            _players.Add(player);
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

        public void DrawCards(int drawCount) {
            foreach (IPlayer player in _players) {
                if (player.Deck != null && player.Deck.Cards.Count != 0) {
                    for (int i = 0; i < drawCount; i++) {
                        player.Hand.AddCard(player.Deck.Cards.Dequeue());
                    }
                }
            }
        }
    }
}


