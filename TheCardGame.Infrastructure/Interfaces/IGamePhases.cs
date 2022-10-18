namespace TheCardGame.Infrastructure.Interfaces {
    public interface IGamePhases {
        public IGamePhase CurrentPhase { get; set; }

        public void AddPhase(IGamePhase newPhase);
        public void RemovePhase(IGamePhase phase);
        public void SetCurrentPhase(IGamePhase current);
    }
}