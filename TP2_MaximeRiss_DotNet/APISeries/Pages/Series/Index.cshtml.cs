using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using APISeries.Models.EntityFramework;

namespace APISeries.Pages.Series
{
    public class IndexModel : PageModel
    {
        private readonly APISeries.Models.EntityFramework.SeriesDBContext _context;

        public IndexModel(APISeries.Models.EntityFramework.SeriesDBContext context)
        {
            _context = context;
        }

        public IList<Serie> Serie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Serie != null)
            {
                Serie = await _context.Serie.ToListAsync();
            }
        }
    }
}
