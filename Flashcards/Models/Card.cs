namespace Flashcards.Models
{
    public class Card
    {
        //[Key]
        public int id { get; set; }
        //[Required]
        public string Category { get; set; }
        //[Required]
        public string Question { get; set; }
        
        public string? Code { get; set; }

        public string? Image { get; set; }
        //[Required]
        public string Answer { get; set; }

        public Card()
        {
            // Placeholder
        }
    }
}
