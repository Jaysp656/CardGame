namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IAttribute
    {
        string Name { get; set; }
        string Description { get; set; }
        string Type { get; set; }

        void DoAttributeEffect();
    }
}
