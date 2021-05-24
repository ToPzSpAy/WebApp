using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstructWedDb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ConstructWedDb.Pages.FilReq.Request
{
    public class LiBriModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;

        public LiBriModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }
        public IList<Brigade> Brigade { get; set; }
        public IList<Staff> Staff { get; set; }
        public async Task OnGetAsync()
        {
            Brigade = await _context.Brigade.ToListAsync();
            Staff = await _context.Staff.ToListAsync();
        }
    }
}
