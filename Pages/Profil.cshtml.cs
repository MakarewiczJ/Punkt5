using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ulubione.Data;
using Ulubione.Models;

namespace Ulubione.Pages
{
    public class ProfilModel : PageModel
    {
        private readonly PrzepisyContext _context;
        public ProfilModel(PrzepisyContext context)
        {
            _context = context;
        }
        public IList<Przepis> Przepisy { get; set; }
        public Przepis Przepis { get; set; }
        public async Task OnGetAsync(string? id)
        {
            Przepisy = await _context.Przepis.ToListAsync();
            var nazwy = from m in Przepisy select m;
            if (!string.IsNullOrEmpty(id))
            {
                nazwy = nazwy.Where(s => (s.UName.Contains(id)));
                Przepisy = nazwy.ToList();
            }
        }
    }
}
