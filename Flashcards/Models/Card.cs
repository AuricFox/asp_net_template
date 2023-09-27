namespace Flashcards.Models
{
    public class Card
    {
        public int id { get; set; }

        public string Category { get; set; }

        public string Question { get; set; }

        public string? Code { get; set; }

        public string? Image { get; set; }

        public string Answer { get; set; }

        public Card()
        {
            // Placeholder
        }
    }
}
