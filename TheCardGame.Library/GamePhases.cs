namespace TheCardGame.Library {
    public class GamePhases {
        public GamePhase CurrentPhase { get; set; }

        List<GamePhase> phases { get; set; }

        public GamePhases() { }

        public void AddPhase(GamePhase newPhase) { 
            phases.Add(newPhase);
        }

        public void SetCurrenPhase(GamePhase current) {
            if (!phases.Contains(current)) {
                throw new Exception($"Phase {current.Title} is not in game phase list");
            }

            CurrentPhase = current;
        }
    }
}