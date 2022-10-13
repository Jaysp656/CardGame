using System.Collections;
using System.Collections.Generic;
using TheCardGame.Data.Models;
using TheCardGame.Data.Queries;
using TheCardGame.Domain.Entities;
using TheCardGame.Infrastructure.Interfaces;

namespace TheCardGame.Library
{
    public class DeckManager : IDeckManager {
        List<Deck> deckCache = new List<Deck>();
        public DeckManager() {
            LoadDecks();
        }

        private void LoadDecks() {
            //NOTE: Could load this based on "type"
            IEnumerable<DeckModel> decks = DeckJsonLoader.LoadDecks();
            foreach (var deck in decks) {
                Deck newDeck = new Deck {
                    Name = deck.Name,
                    Description = deck.Description,
                    Cards = new Queue<ICard>()
                };
                foreach (var cardModel in deck.Cards) {
                    Card card = new Card {
                        Name = cardModel.Name,
                        Description = cardModel.Description,
                        Type = cardModel.Type,
                        Attributes = cardModel.Attributes,
                        Properties = cardModel.Properties
                    };
                    newDeck.Cards.Enqueue(card);
                }
                deckCache.Add(newDeck);
            }
        }

        public IDeck GetDeck(string deckName) {            
            try {
                return deckCache.Single(d => d.Name == deckName);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                throw;
            }            
        }

        public IEnumerable<IDeck> GetDecks() {
            try {
                return deckCache;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public bool HasDeck(string deckName) {
            try {
                return deckCache.Where(d => d.Name == deckName).Any();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void Shuffle(IDeck deck) { 
            var random = new System.Random();
            var n = deck.Cards.Count;
            var cards = deck.Cards.ToList();

            for (int i = 0; i < n; i++) {
                var r = i + random.Next(n - 1);
                (cards[i], cards[r]) = (cards[r], cards[i]);
            }

            deck.Cards = new Queue<ICard>(cards);
        }
    }
}
