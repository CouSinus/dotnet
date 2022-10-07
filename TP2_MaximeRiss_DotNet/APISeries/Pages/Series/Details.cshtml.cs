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
    public class DetailsModel : PageModel
    {
        private readonly APISeries.Models.EntityFramework.SeriesDBContext _context;

        public DetailsModel(APISeries.Models.EntityFramework.SeriesDBContext context)
        {
            _context = context;
        }

      public Serie Serie { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serie == null)
            {
                return NotFound();
            }

            var serie = await _context.Serie.FirstOrDefaultAsync(m => m.SerieId == id);
            if (serie == null)
            {
                return NotFound();
            }
            else 
            {
                Serie = serie;
            }
            return Page();
        }
    }
}
