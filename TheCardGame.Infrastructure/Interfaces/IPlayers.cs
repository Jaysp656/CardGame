namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IPlayers
    {
        public void AddPlayer(IPlayer player);
        void Clear();
        void DrawCards(int drawCount);
        List<IPlayer> GetPlayers();
        void RemovePlayer(IPlayer player);
        void ShuffleDeck(IPlayer player);
        void ShuffleDecks();
    }
}
