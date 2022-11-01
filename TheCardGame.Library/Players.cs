﻿using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public class Players : IPlayers {
        private List<IPlayer> _players = new();

        public IPlayer CurrentPlayer { get; private set; }

        public Players() {}

        public void AddPlayer(IPlayer player) {
            if(player == null) throw new ArgumentNullException(nameof(player));
            
            _players.Add(player);

            CurrentPlayer ??= _players[0];
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


