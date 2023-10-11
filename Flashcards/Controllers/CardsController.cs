using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Flashcards.Data;
using Flashcards.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;

namespace Flashcards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CardsController> _logger;

        public CardsController(ApplicationDbContext context, ILogger<CardsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // ==============================================================================================
        // MAIN VIEW METHODS
        // ==============================================================================================
        // GET: Cards
        public async Task<IActionResult> Index()
        {
              return _context.Card != null ? 
                          View(await _context.Card.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Card'  is null.");
        }

        // ==============================================================================================
        // Get all Card categories
        public async Task<IActionResult> Display_Cards(string categoryId)
        {
            _logger.LogInformation($"Display Flashcards, Category: {categoryId}.");
            if (_context.Card == null)
            {
                _logger.LogError($"Error Displaying Flashcards!");
                return NotFound();
            }

            // Load the list of categories to populate the dropdown
            var categories = _context.GetDistinctCategories();
            var categoryList = new SelectList(categories, "Category", "Category");

            if (string.IsNullOrEmpty(categoryId))
            {
                // If categoryId is null, show all cards
                var allCards = await _context.Card.ToListAsync();
                ViewBag.CategoryList = categoryList;
                ViewBag.FilteredCards = allCards;
                return View();
            }

            // Filter the "Card" records based on the selected category
            var filteredCards = await _context.Card
                .Where(c => c.Category == categoryId)
                .ToListAsync();

            // Store the data in ViewBag to pass to the view
            ViewBag.CategoryList = categoryList;
            ViewBag.FilteredCards = filteredCards;

            return View();
        }

        // ==============================================================================================
        // CARD DATABASE QUERIES
        // ==============================================================================================
        // GET: Cards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                .FirstOrDefaultAsync(m => m.id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // ==============================================================================================
        // GET: Cards/Create
        public IActionResult Create()
        {
            return View();
        }

        // ==============================================================================================
        // POST: Cards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Category,Question,Code,Image,Answer")] Card card)
        {
            if (ModelState.IsValid)
            {
                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // ==============================================================================================
        // GET: Cards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card = await _context.Card.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            return View(card);
        }

        // ==============================================================================================
        // POST: Cards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Category,Question,Code,Image,Answer")] Card card)
        {
            if (id != card.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(card);
        }

        // ==============================================================================================
        // GET: Cards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                .FirstOrDefaultAsync(m => m.id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // ==============================================================================================
        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Card == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Card'  is null.");
            }
            var card = await _context.Card.FindAsync(id);
            if (card != null)
            {
                _context.Card.Remove(card);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ==============================================================================================
        private bool CardExists(int id)
        {
          return (_context.Card?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
