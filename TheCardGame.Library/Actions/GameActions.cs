using System;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library.Actions
{
    public class GameActions : IGameActions
    {
        public Dictionary<string, IGameAction> Actions { get; set; } = new Dictionary<string, IGameAction>();

        public GameActionType Type { get; }

        public GameActions(GameActionType actionType) {
            Type = actionType;
        }

        public bool Add(IGameAction newAction)
        {
            return Actions.TryAdd(newAction.Name, newAction);
        }

        public void Remove(IGameAction newAction)
        {
            Actions.Remove(newAction.Name);
        }

        public void ListActions() {
            foreach (var action in Actions) {
                Console.WriteLine($"{action.Key} : {action.Value.Name} - {action.Value.Description}");
            }
        }

        //public IGameActions GetActionsByType(GameActionType type) {
        //    IGameActions subGameActions = new GameActions { 
        //        Actions = Actions.Where(x => x.Value.Type == type).ToDictionary(dict => dict.Key, dict => dict.Value) 
        //    };
        //    return subGameActions;
        //}

        public void DoAction(string actionName, params object[] p)
        {
            if (Actions.ContainsKey(actionName))
            {
                Actions.TryGetValue(actionName, out IGameAction? selectedAction);
                selectedAction?.DoAction.Invoke(p);
            }

        }
    }
}
