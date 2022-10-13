namespace TheCardGame.Data.Models {
    public class CardModel {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; }
        public List<string> Attributes { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
}
