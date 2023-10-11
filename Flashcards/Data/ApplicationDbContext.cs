using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Flashcards.Models;

namespace Flashcards.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Flashcards.Models.Card>? Card { get; set; }

        public IEnumerable<string>? GetDistinctCategories()
        {
            // Intial DB may be empty, return null for this edgecase
            if (Card == null) return null;

            // Return the distinct categories in the DB
            return Card.Select(card => card.Category).Distinct();
        }
    }
}