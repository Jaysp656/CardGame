using System;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Application.Details {
    public class GameActions : IGameActions {
        private Dictionary<string, IGameAction> Actions { get; set; } = new Dictionary<string, IGameAction>();
        public bool CurrentPlayerActions { get; set; } = false;

        public GameActions() {}

        public bool Add(IGameAction newAction) {
            return Actions.TryAdd(newAction.Name, newAction);
        }

        public void Remove(IGameAction newAction) {
            Actions.Remove(newAction.Name);
        }

        public void ListActions() {
            foreach (var actionNames in Actions.Keys) { 
                Console.WriteLine(actionNames);
            }
        }


        //TODO: need better implementation of actions. Need a way to pass different parameters based on the action...
        public void DoAction(string actionName, params object[] p) {
            if (Actions.ContainsKey(actionName)) {
                Actions.TryGetValue(actionName, out IGameAction selectedAction);
                selectedAction?.DoAction.Invoke(p);
            }

        }
    }
}
