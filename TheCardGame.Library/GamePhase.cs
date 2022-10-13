using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public class GamePhase {
        public string Title { get; set; }
        public string Description { get; set; }

        private GamePhase _nextPhase;

        public GamePhase(string title, string description) {
            Title = title;
            Description = description;
        }

        public void SetNextPhase(GamePhase next) {
            _nextPhase = next;
        }

        public void StartPhase() { 
        }

        public GamePhase StopPhase() {

            //TODO: how to change which phase based on conditions like ending game?
            return _nextPhase;
        }
    }
}