using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConstructWedDb.Models;
using WebApp.Data;

namespace WebApp.Pages.TypeOfJobs
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;

        public IndexModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        public IList<TypeOfJob> TypeOfJob { get;set; }

        public async Task OnGetAsync()
        {
            TypeOfJob = await _context.TypeOfJob
                .Include(t => t.Material1)
                .Include(t => t.Material2)
                .Include(t => t.Material3).ToListAsync();
        }
    }
}
