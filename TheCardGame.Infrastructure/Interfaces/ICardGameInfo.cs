using TheCardGame.Domain.Entities;

namespace TheCardGame.Infrastructure.Interfaces {
    public interface ICardGameInfo {
        public IPlayers Players { get; set; }
        public IGamePhases Phases { get; set; }
        public IDeckManager DeckManager { get; set; }
        public IGameBoard GameBoard { get; set; } 
    }
}