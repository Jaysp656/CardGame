using TheCardGame.Library.Actions;

namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IGameActions
    {
        Dictionary<string, IGameAction> Actions { get; set; }
        public GameActionType Type { get; }
        public bool Add(IGameAction newAction);
        public void Remove (IGameAction newAction);
        public void ListActions();
        void DoAction(string actionName, params object[] p);
    }
}