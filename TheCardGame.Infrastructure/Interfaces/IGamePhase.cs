using TheCardGame.Library.Actions;

namespace TheCardGame.Infrastructure.Interfaces {
    public interface IGamePhase {
        string Description { get; set; }
        string Title { get; set; }
        void AddPlayerAction(IGameAction action, bool isCurrentPlayerAction);
        void RemovePlayerAction(IGameAction drawAction, bool isCurrentPlayerAction);
        IGamePhase? Next();
        void SetNextPhase(IGamePhase next);
        void Start();
        IGameActions GetActionsOfType(GameActionType type);
    }
}