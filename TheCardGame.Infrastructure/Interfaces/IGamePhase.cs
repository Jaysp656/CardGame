namespace TheCardGame.Infrastructure.Interfaces {
    public interface IGamePhase {
        string Description { get; set; }
        string Title { get; set; }
        void AddPlayerAction(IGameAction drawAction);
        void RemovePlayerAction(IGameAction drawAction);
        IGamePhase? Next();
        void SetNextPhase(IGamePhase next);
        void Start();
        IGameActions GetPlayerActions();
    }
}