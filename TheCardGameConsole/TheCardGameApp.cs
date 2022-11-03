using TheCardGame.Application.Details;
using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library;
using TheCardGame.Library.PlayerLib;

namespace TheCardGame.Console {
    public static class TheCardGameApp
    {
        public static void Run()
        {
            DeckManager deckManager = new();
            IGamePhases gamePhases = GameDetailsBuilder.GetGamePhases();
            Players players = new();                     

            ICardGameBuilder GameBuilder = new CardGameBuilder(gamePhases, deckManager, players);
            
            var playerOne = new PlayerBuilder().Name("John").Health(10).FirstPlayer().Build();
            var playerTwo = new PlayerBuilder().Name("Jane").Health(10).Build();

            GameBuilder.AddPlayer(playerOne, 1)
                .AddPlayer(playerTwo, 2);

            //TODO: create class to configure aspects of game?
            //_manager.ConfigureGame()
            ICardGame cg = GameBuilder.Build();
            cg.AddGamePhases(gamePhases);
            cg.Start();


            cg.GetPlayerActions(playerOne.Id);
            cg.DoAction("Draw Card", playerOne.Id, 1);
        }
    }
}
