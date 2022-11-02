namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IDeck
    {
        int? Id { get; set; }
        string? Name { get; set; }
        string? Description { get; set; }
        Queue<ICard>? Cards { get; set; }
    }
}