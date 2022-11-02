namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Health { get; set; }
        int? DeckId { get; set; }
        IHand Hand { get; set; }
        bool Quit { get; set; }
        bool CurrentTurn { get; set; }
    }
}
