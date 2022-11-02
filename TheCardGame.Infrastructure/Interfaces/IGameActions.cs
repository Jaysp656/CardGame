namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IGameActions
    {
        bool CurrentPlayerActions { get; set; }

        public bool Add(IGameAction newAction);
        public void Remove (IGameAction newAction);
        public void ListActions();
        void DoAction(string actionName, params object[] p);
    }
}