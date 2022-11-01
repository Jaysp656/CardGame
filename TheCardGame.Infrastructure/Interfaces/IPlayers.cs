namespace TheCardGame.Infrastructure.Interfaces
{
    public interface IPlayers{
        IPlayer CurrentPlayer { get; }

        public void AddPlayer(IPlayer player);
        void Clear();
        List<IPlayer> GetPlayers();
    }
}
