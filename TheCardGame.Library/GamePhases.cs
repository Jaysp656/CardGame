using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public class GamePhases : IGamePhases {
        public IGamePhase CurrentPhase { get; set; }
        private List<IGamePhase> _phases { get; set; } = new List<IGamePhase>();

        public GamePhases() {}

        public void AddPhase(IGamePhase newPhase) {            
            _phases.Add(newPhase);
            CurrentPhase ??= _phases[0];
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

        public void SetNextPhase() {
            if (!_phases.Contains(CurrentPhase)) {
                throw new Exception($"Phase {CurrentPhase.Title} is not in game phase list");
            }
            int nextIndex = _phases.IndexOf(CurrentPhase) + 1;
            if (nextIndex >= _phases.Count) {
                //TODO: set up auto phases to process moving to next player?
                CurrentPhase = _phases[0];
                return;
            }
            CurrentPhase = _phases[nextIndex];
        }
    }
}