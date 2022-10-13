using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library;

namespace TheCardGame.Console {
    public class TheCardGameApp
    {
        readonly ICardGameBuilder _gameBuilder;
        public TheCardGameApp(ICardGameBuilder gameBuilder)
        {
            _gameBuilder = gameBuilder;            
        }

        public void Run()
        {
            var playerOne = new Player { Name = "John", Deck = new Deck(), Hand = new Hand(), Health = 10 };
            var playerTwo = new Player { Name = "Jane", Deck = new Deck(), Hand = new Hand(), Health = 10 };

            _gameBuilder.AddPlayer(playerOne, "Dragon Deck");
            _gameBuilder.AddPlayer(playerTwo, "Knight Deck");


            //TODO: create class to configure aspects of game?
            //_manager.ConfigureGame()
            _gameBuilder.InitialCardDrawCount(5);     
            
            ICardGame cg = _gameBuilder.Build();

            cg.Start();
        }
    }
}
