namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IAction
    {
        string Name { get; }
        string Description { get; }
        void DoAction();
    }
}