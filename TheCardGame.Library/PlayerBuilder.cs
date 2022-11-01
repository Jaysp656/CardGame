using TheCardGame.Application.Details;
using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public class PlayerBuilder {
        private IPlayer _player;
        private IHand _hand;
        private IDeck _deck;
        private bool _currentTurn = false;
        private IGameActions _gameActions;

        public PlayerBuilder() {
            _player = new Player();
            _hand = new Hand();
            _deck = new Deck();
            _gameActions = new GameActions(); 
        }

        public PlayerBuilder Name(string name) {
            _player.Name = name;
            return this;
        }
        public PlayerBuilder Health(int health) {
            _player.Health = health;
            return this;
        }
        public PlayerBuilder Hand(IHand hand) {
            _player.Hand = hand;
            return this;
        }
        public PlayerBuilder Deck(IDeck deck) {
            _player.Deck = deck;
            return this;
        }
        public PlayerBuilder Actions(IGameActions actions) {
            _player.Actions = actions;
            return this;
        }

        public PlayerBuilder FirstPlayer() { 
            _currentTurn = true;
            return this;
        }

        public IPlayer Build() {
            _player.Deck = _deck;
            _player.Hand = _hand;
            _player.Actions = _gameActions;
            _player.CurrentTurn = _currentTurn;
            return _player;
        }
    }
}
