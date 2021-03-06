using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConstructWedDb.Models;
using WebApp.Data;

namespace WebApp.Pages.Orders
{
    public class EditModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;

        public EditModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Order
                .Include(o => o.Brigade)
                .Include(o => o.Customer)
                .Include(o => o.Staff)
                .Include(o => o.TypeOfJob).FirstOrDefaultAsync(m => m.ID == id);

            if (Order == null)
            {
                return NotFound();
            }
           ViewData["BrigadeID"] = new SelectList(_context.Brigade, "ID", "ID");
           ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "ID");
           ViewData["StaffID"] = new SelectList(_context.Set<Staff>(), "ID", "ID");
           ViewData["TypeOfJobID"] = new SelectList(_context.Set<TypeOfJob>(), "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(Order.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrderExists(long id)
        {
            return _context.Order.Any(e => e.ID == id);
        }
    }
}
