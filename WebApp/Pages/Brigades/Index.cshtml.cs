using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConstructWedDb.Models;
using WebApp.Data;

namespace WebApp.Pages.Brigades
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;

        public IndexModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        public IList<Brigade> Brigade { get;set; }

        public async Task OnGetAsync()
        {
            Brigade = await _context.Brigade
                .Include(b => b.Staff1)
                .Include(b => b.Staff2)
                .Include(b => b.Staff3).ToListAsync();
        }
    }
}
