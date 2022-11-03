using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library.Actions;

namespace TheCardGame.Library.Phases
{


    public class GamePhase : IGamePhase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        private List<IGameActions> Actions { get; set; } = new List<IGameActions>();

        private IGamePhase? _nextPhase = null;

        public delegate GamePhase Factory(string title, string description);

        public GamePhase(string title, string description)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        public GamePhase() { }

        public void SetNextPhase(IGamePhase next)
        {
            _nextPhase = next;
        }

        public void Start()
        {
            //TODO: start phase actions?
            //Add more lifecycle methods?
        }

        public void EndPhase() { 
        
        }


        public IGamePhase? Next()
        {
            if (_nextPhase == null)
            {
                Console.WriteLine($"Phase {Title} has no next phase");
                return null;
            }
            return _nextPhase;
        }

        public void AddPlayerAction(IGameAction action, bool isCurrentPlayerAction)
        {
            var type = isCurrentPlayerAction ? GameActionType.CurrentPlayer : GameActionType.Player;
            if (!Actions.Any(actionList => actionList.Type == type)) {
                Actions.Add(new GameActions(type));
            }

            Actions.SingleOrDefault(actionList => actionList.Type == type).Add(action);
        }
        public void RemovePlayerAction(IGameAction action, bool isCurrentPlayerAction)
        {
            var type = isCurrentPlayerAction ? GameActionType.CurrentPlayer : GameActionType.Player;
            GetActionsOfType(type)?.Remove(action);
        }

        public IGameActions GetActionsOfType(GameActionType type)
        {  
            return Actions.SingleOrDefault(action => action.Type == type);
        }
    }
}