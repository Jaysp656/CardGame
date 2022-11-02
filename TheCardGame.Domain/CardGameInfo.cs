using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Domain {
    public class CardGameInfo : ICardGameInfo {
        public IGameBoard GameBoard { get; set; } = new GameBoard();
        public IPlayers Players { get; set; }
        public IDeckManager DeckManager { get; set; }
        public IGamePhases Phases { get; set; }
    }
}
