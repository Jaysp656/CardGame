using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Console {
    public class TheCardGameApp
    {
        readonly ICardGameManager _manager;
        public TheCardGameApp(ICardGameManager manager)
        {
            _manager = manager;            
        }

        public void Run()
        {
            var playerOne = new Player { Name = "John", Deck = new Deck(), Hand = new Hand(), Health = 10 };
            var playerTwo = new Player { Name = "Jane", Deck = new Deck(), Hand = new Hand(), Health = 10 };

            _manager.AddPlayer(playerOne, "Dragon Deck");
            _manager.AddPlayer(playerTwo, "Knight Deck");

            //TODO: create class to configure aspects of game?
            //_manager.ConfigureGame()

            _manager.StartGame();

        }

    }
}
