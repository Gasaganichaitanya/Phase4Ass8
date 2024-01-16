using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppAzureAss8.Models;

namespace WebAppAzureAss8.Controllers
{
    public class BookCategoriesController : Controller
    {
        private readonly Books8919dbContext _context;

        public BookCategoriesController(Books8919dbContext context)
        {
            _context = context;
        }

        // GET: BookCategories
        public async Task<IActionResult> Index()
        {
              return _context.BookCategories != null ? 
                          View(await _context.BookCategories.ToListAsync()) :
                          Problem("Entity set 'Books8919dbContext.BookCategories'  is null.");
        }

        // GET: BookCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookCategories == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategories
                .FirstOrDefaultAsync(m => m.BookCategoryId == id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        // GET: BookCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookCategoryId,Category")] BookCategory bookCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookCategory);
        }

        // GET: BookCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BookCategories == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategories.FindAsync(id);
            if (bookCategory == null)
            {
                return NotFound();
            }
            return View(bookCategory);
        }

        // POST: BookCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookCategoryId,Category")] BookCategory bookCategory)
        {
            if (id != bookCategory.BookCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCategoryExists(bookCategory.BookCategoryId))
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
            return View(bookCategory);
        }

        // GET: BookCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BookCategories == null)
            {
                return NotFound();
            }

            var bookCategory = await _context.BookCategories
                .FirstOrDefaultAsync(m => m.BookCategoryId == id);
            if (bookCategory == null)
            {
                return NotFound();
            }

            return View(bookCategory);
        }

        // POST: BookCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BookCategories == null)
            {
                return Problem("Entity set 'Books8919dbContext.BookCategories'  is null.");
            }
            var bookCategory = await _context.BookCategories.FindAsync(id);
            if (bookCategory != null)
            {
                _context.BookCategories.Remove(bookCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCategoryExists(int id)
        {
          return (_context.BookCategories?.Any(e => e.BookCategoryId == id)).GetValueOrDefault();
        }
    }
}
