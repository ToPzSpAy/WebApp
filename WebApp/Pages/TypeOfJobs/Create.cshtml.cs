using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConstructWedDb.Models;
using WebApp.Data;

namespace WebApp.Pages.TypeOfJobs
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;

        public CreateModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Material1ID"] = new SelectList(_context.Material, "ID", "ID");
        ViewData["Material2ID"] = new SelectList(_context.Material, "ID", "ID");
        ViewData["Material3ID"] = new SelectList(_context.Material, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public TypeOfJob TypeOfJob { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TypeOfJob.Add(TypeOfJob);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
