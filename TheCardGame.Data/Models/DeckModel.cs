using TheCardGame.Domain.Entities;

namespace TheCardGame.Data.Models {
    public class DeckModel {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CardModel> Cards { get; set; }
    }
}
