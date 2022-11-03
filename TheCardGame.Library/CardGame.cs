﻿using TheCardGame.Infrastructure.Interfaces;
using TheCardGame.Library.Actions;
using TheCardGame.Library.Phases;

namespace TheCardGame.Library
{
    public class CardGame : ICardGame {
        int ICardGame.InitialDrawCount { get; set; }
        public ICardGameInfo CardGameInfo { get; }

        public int InitialDrawCount = 0;

        public CardGame(ICardGameInfo cardGameInfo) {
            CardGameInfo = cardGameInfo;
        }

        public void Start() {
            if (CardGameInfo.Players == null) { throw new Exception("Players has not been initialized"); }
            Console.WriteLine("Let the games begin!");            
            NextPhase();
        }

        public void AddPlayers(IPlayers players) {
            CardGameInfo.Players = players;
        }

        public void AddDeckManager(IDeckManager deckMgr) {
            CardGameInfo.DeckManager = deckMgr;
        }

        public void DoAction(string actionName, int playerId, int DeckId) {
            //How to handle the parameters of each action if they vary between each one?
            //Maybe each action's parameters can be saved somewhere and retrieved for use when the action is run?
            IPlayer? player = CardGameInfo.Players.GetPlayers().SingleOrDefault(x => x.Id == playerId);
            var type = player.CurrentTurn ? GameActionType.CurrentPlayer : GameActionType.Player;

            IGameActions playerActions = CardGameInfo.Phases.CurrentPhase.GetActionsOfType(type);
            playerActions.DoAction(actionName, CardGameInfo, playerId, DeckId);

        }

        public void GetPlayerActions(int playerId) {
            IPlayer? player = CardGameInfo.Players.GetPlayers().SingleOrDefault(x => x.Id == playerId);
            Console.WriteLine($"Listing player {player?.Id} actions: ");

            var type = player.CurrentTurn ? GameActionType.CurrentPlayer : GameActionType.Player;
            CardGameInfo.Phases.CurrentPhase.GetActionsOfType(type).ListActions();

        }

        public void NextPhase() {
            CheckEndGameConditions();
            CardGameInfo.Phases.SetNextPhase();

            //TODO: need to combine these together
            //Actions.Clear();
            //Actions.Add(CardGameInfo.Phases.CurrentPhase.GetPlayerActions(true));
            //Actions.Add(CardGameInfo.Phases.CurrentPhase.GetPlayerActions(false));
        }

        private void CheckEndGameConditions() {
            if (isGameEnded()) {
                Stop();
            }
        }

        public void Stop() {
            Console.WriteLine("Game has ended");
        }

        public void AddGamePhases(IGamePhases gamePhases) {
            CardGameInfo.Phases = (GamePhases)gamePhases;
        }

        private bool isGameEnded() {
            //setup rules for game end
            //TODO: setup tie condition?
            if (CardGameInfo.Players == null) { throw new Exception("No players exist when checking if game is ended"); }

            if (CardGameInfo.Players.GetPlayers().Where(x => x.Health > 0).Count() == 1) {
                IPlayer winner = CardGameInfo.Players.GetPlayers().Single(x => x.Health > 0);
                Console.WriteLine($"{winner.Name} has won the game!");
                return true;
            }
            if (CardGameInfo.Players.GetPlayers().Where(x => !x.Quit).Count() == 1 ) {
                Console.WriteLine($"Only one player remaining, the game has ended.");
                return true;
            }

            return false;
        }
    }
}