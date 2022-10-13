namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IDeck
    {
        string Name {get; set;}
        string Description {get; set;}
        //void Shuffle();
        //IEnumerable<ICard> Draw();
        Queue<ICard> Cards {get; set;}
    }
}