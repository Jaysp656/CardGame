using TheCardGame.Application.Details.Actions;
using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library;

namespace TheCardGame.Application.Details
{
    public class GameDetailsBuilder
    {
        private readonly GamePhase.Factory _phaseFactory;
        public GameDetailsBuilder(GamePhase.Factory phaseFac) {
            _phaseFactory = phaseFac ?? throw new ArgumentNullException(nameof(phaseFac));
        }

        public IGamePhases GetGamePhases(IGamePhases phases, ICardGame cardGame)
        {

            IGamePhase drawPhase = _phaseFactory("Drawing Phase", "Current player draws a card");
            drawPhase.AddPlayerAction(new DrawAction(cardGame), true);

            phases.AddPhase(drawPhase);
            phases.CurrentPhase = drawPhase;

            return phases;
        }    
    }
}
