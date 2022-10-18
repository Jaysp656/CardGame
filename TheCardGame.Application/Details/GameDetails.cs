using TheCardGame.Application.Details.Actions;
using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library;

namespace TheCardGame.Application.Details
{
    public class GameDetails
    {
        public static IGamePhases GetGamePhases()
        {
            IGamePhases phases = new GamePhases();

            IGamePhase drawPhase = new GamePhase("Drawing Phase", "Current player draws a card");
            drawPhase.AddPlayerAction(new DrawAction {
                Name = "Draw Action",
                Description = "draws card from player's deck to hand"
            }, true);

            phases.AddPhase(drawPhase);
            phases.CurrentPhase = drawPhase;

            return phases;
        }    
    }
}
