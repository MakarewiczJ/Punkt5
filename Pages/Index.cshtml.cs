using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ulubione.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Ulubione.Models;

namespace Ulubione.Pages
{
    public class IndexModel : PageModel
    {
        private readonly PrzepisyContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Przepis Przepis { get; set; }
        //[BindProperty]
        //public UlubioneModel UlubioneModel { get; set; }
        public IndexModel(ILogger<IndexModel> logger, PrzepisyContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public string TekstWyszukiwania { get; set; }
        public IList<Przepis> Przepisy { get; set; }
        public async Task OnGetAsync()
        {
            Przepisy = await _context.Przepis.ToListAsync();
            var nazwy = from m in Przepisy select m;
            if (!string.IsNullOrEmpty(TekstWyszukiwania))
            {
                nazwy = nazwy.Where(s => (s.Nazwa.Contains(TekstWyszukiwania)) || (s.UName.Contains(TekstWyszukiwania)));
                Przepisy = nazwy.ToList();
            }
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("./DodawaniePrzepisu");
        }
        //public async Task<IActionResult> OnPostUlub(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    if (string.IsNullOrEmpty(UlubioneModel.Nickname))
        //    {
        //        UlubioneModel.Nickname = _userManager.GetUserName(HttpContext.User);
        //    }


        //    Przepis = await _context.Przepis.FindAsync(id);
        //    if(UlubioneModel.UlubionePrzepisy==null)
        //    {
        //        UlubioneModel.UlubionePrzepisy.Add(Przepis);
        //        await _context.SaveChangesAsync();
        //    }
        //    else if ((Przepis != null) && !(UlubioneModel.UlubionePrzepisy.Contains(Przepis)))
        //    {
        //        UlubioneModel.UlubionePrzepisy.Add(Przepis);
        //        await _context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        return base.NotFound();
        //    }
        //    return RedirectToPage("./Index");

        //}
    }
}
