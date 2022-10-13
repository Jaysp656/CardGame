namespace TheCardGame.Infrastructure.Interfaces
{
    public interface ICard
    {
        string Name { get; }
        string Description { get; }
        string Type { get; set; }
        IEnumerable<string> Attributes { get; set; }
        Dictionary<string, string> Properties { get; set; }
    }
}
