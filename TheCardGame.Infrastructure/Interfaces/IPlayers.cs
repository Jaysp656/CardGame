namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IPlayers{
        IPlayer CurrentPlayer { get; }

        public void AddPlayer(IPlayer player);
        void Clear();
        void DrawCards(int drawCount);
        void DrawCards(int drawCount, IPlayer player);
        void SetCurrentPlayer(IPlayer player);
        List<IPlayer> GetPlayers();
        void RemovePlayer(IPlayer player);
        void ShuffleDeck(IPlayer player);
        void ShuffleDecks();
    }
}
