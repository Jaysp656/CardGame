using TheCardGame.Application.Details;
using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library;

namespace TheCardGame.Console
{
    public class TheCardGameApp
    {
        readonly ICardGameBuilder GameBuilder;
        readonly PlayerBuilder.Factory PlayerBuilder;
        public TheCardGameApp(ICardGameBuilder gameBuilder, PlayerBuilder.Factory playerBuilder)
        {
            GameBuilder = gameBuilder ?? throw new ArgumentNullException(nameof(gameBuilder));
            PlayerBuilder = playerBuilder ?? throw new ArgumentNullException(nameof(playerBuilder));
        }

        public void Run()
        {

            var playerOne = PlayerBuilder().Name("John").Health(10).FirstPlayer().Build();
            var playerTwo = PlayerBuilder().Name("Jane").Health(10).Build();

            GameBuilder.AddPlayer(playerOne, "Dragon Deck")
                .AddPlayer(playerTwo, "Knight Deck");;

            //TODO: create class to configure aspects of game?
            //_manager.ConfigureGame()
            GameBuilder.InitialCardDrawCount(5);     
            
            ICardGame cg = GameBuilder.Build();

            cg.Start();

            playerOne.Actions.ListActions();
            playerOne.Actions.DoAction("Draw Action");
        }
    }
}
