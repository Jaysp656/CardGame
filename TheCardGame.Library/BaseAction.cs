using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library {
    public class BaseAction : IGameAction {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual void DoAction(ICardGame game) {}
    }
}
