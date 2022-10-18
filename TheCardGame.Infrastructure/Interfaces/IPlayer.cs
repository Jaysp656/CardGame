namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IPlayer
    {
        public string Name { get; set; }
        public double Health { get; set; }
        IDeck Deck { get; set; }
        IHand Hand { get; set; }
        IGameActions Actions { get; set; }
        bool Quit { get; set; }
        bool CurrentTurn { get; set; }
    }
}
