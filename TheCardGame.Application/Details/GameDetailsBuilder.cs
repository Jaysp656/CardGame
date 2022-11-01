using TheCardGame.Application.Details.Actions;
using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library;

namespace TheCardGame.Application.Details
{
    public class GameDetailsBuilder
    {
        public static IGamePhases GetGamePhases()
        {
            GamePhases gamePhases = new();
            gamePhases.AddPhase(GetDrawPhase());
            return gamePhases;
        }

        private static GamePhase GetDrawPhase() {
            GamePhase gamePhase = new();

            gamePhase.AddPlayerAction(new DrawAction(), true);


            return gamePhase;
        }
    }
}
