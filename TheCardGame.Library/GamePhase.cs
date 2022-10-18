using TheCardGame.Application.Details;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {

    
    public class GamePhase : IGamePhase {
        public string Title { get; set; }
        public string Description { get; set; }
        private IGameActions PlayerActions { get; set; }
        private IGameActions CurrentPlayerActions { get; set; }

        private IGamePhase? _nextPhase = null;

        public delegate GamePhase Factory(string title, string description);

        public GamePhase(string title, string description) {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public GamePhase() {}

        public void SetNextPhase(IGamePhase next) {
            _nextPhase = next;
        }

        public void Start() {
            //TODO: start phase actions?
        }

        public IGamePhase? Next() {
            if (_nextPhase == null) {
                Console.WriteLine($"Phase {Title} has no next phase");
                return null;
            }
            return _nextPhase;
        }

        public void AddPlayerAction(IGameAction action, bool isCurrentPlayerAction) {
            GetPlayerActions(isCurrentPlayerAction)?.Add(action);
        }
        public void RemovePlayerAction(IGameAction action, bool isCurrentPlayerAction) {
            GetPlayerActions(isCurrentPlayerAction)?.Remove(action);
        }
        public IGameActions GetPlayerActions(bool isCurrentPlayerAction) {
            IGameActions actions = PlayerActions ??= new GameActions();
            if (isCurrentPlayerAction) {
                actions = CurrentPlayerActions ??= new GameActions();
            }

            return actions;
        }
    }
}