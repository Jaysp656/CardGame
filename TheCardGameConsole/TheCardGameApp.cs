using TheCardGame.Application.Details;
using TheCardGame.Application.Details.Actions;
using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library;

namespace TheCardGame.Console
{
    public class TheCardGameApp
    {

        public TheCardGameApp() {
        }

        public void Run()
        {
            DeckManager deckManager = new();
            Players players = new();

            var playerOne = new PlayerBuilder().Name("John").Health(10).FirstPlayer().Build();
            players.AddPlayer(playerOne);
            var playerTwo = new PlayerBuilder().Name("Jane").Health(10).Build();
            players.AddPlayer(playerTwo);            

            ICardGameBuilder GameBuilder = new CardGameBuilder(players, deckManager);
            GameBuilder.AddPlayer(playerOne, "Dragon Deck")
                .AddPlayer(playerTwo, "Knight Deck");

            //TODO: create class to configure aspects of game?
            //_manager.ConfigureGame()            
            IGamePhases gamePhases = GameDetailsBuilder.GetGamePhases();
            
            ICardGame cg = GameBuilder.Build();
            cg.AddGamePhases(gamePhases);
            cg.Start();


            playerOne.Actions.ListActions();
            playerOne.Actions.DoAction("Draw Card", playerOne, playerOne.Deck, 1);
        }
    }
}
