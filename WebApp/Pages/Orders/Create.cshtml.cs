﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ConstructWedDb.Models;
using WebApp.Data;

namespace WebApp.Pages.Orders
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
        ViewData["BrigadeID"] = new SelectList(_context.Brigade, "ID", "ID");
        ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "ID");
        ViewData["StaffID"] = new SelectList(_context.Set<Staff>(), "ID", "ID");
        ViewData["TypeOfJobID"] = new SelectList(_context.Set<TypeOfJob>(), "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
