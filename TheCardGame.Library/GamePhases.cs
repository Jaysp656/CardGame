using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public class GamePhases : IGamePhases {
        public IGamePhase CurrentPhase { get; set; } = new GamePhase();
        private List<IGamePhase> _phases { get; set; } = new List<IGamePhase>();

        public GamePhases() {}

        public void AddPhase(IGamePhase newPhase) {
            _phases.Add(newPhase);
        }
        public void RemovePhase(IGamePhase phase) {
            _phases.Remove(phase);
        }

        public void SetCurrentPhase(IGamePhase current) {
            if (!_phases.Contains(current)) {
                throw new Exception($"Phase {current.Title} is not in game phase list");
            }

            CurrentPhase = current;
        }
    }
}