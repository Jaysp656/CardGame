namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IActions
    {
        IEnumerable<IAction> Actions { get; }
    }
}