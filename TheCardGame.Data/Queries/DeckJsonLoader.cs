using System.Text.Json;
using TheCardGame.Data.Models;
using TheCardGame.Domain.Entities;

namespace TheCardGame.Data.Queries
{
    public static class DeckJsonLoader
    {
        //public static IEnumerable<Deck> LoadDecks()
        //{
        //    var decklist = new List<Deck>();
        //    try
        //    {
        //        foreach (string file in Directory.GetFiles("Decks").Where(x => x.EndsWith(".json")))
        //        {
        //            using StreamReader sReader = new StreamReader(file);
        //            string json = sReader.ReadToEnd();
        //            Deck newDeck = JsonSerializer.Deserialize<Deck>(json);
        //            decklist.Add(newDeck);
        //            Console.WriteLine($"Added new Deck: {newDeck?.Name}");
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    return decklist;
        //}

        public static IEnumerable<DeckModel> LoadDecks() {
            var decklist = new List<DeckModel>();
            try {
                foreach (string file in Directory.GetFiles("Decks").Where(x => x.EndsWith(".json"))) {
                    using StreamReader sReader = new StreamReader(file);
                    string json = sReader.ReadToEnd();
                    DeckModel newDeck = JsonSerializer.Deserialize<DeckModel>(json);


                    decklist.Add(newDeck);
                    Console.WriteLine($"Added new Deck: {newDeck?.Name}");
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            return decklist;
        }
    }
}
