using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Ulubione.Data;
using Ulubione.Models;

namespace Ulubione.Pages
{
    [Authorize]
    public class DodawaniePrzepisuModel : PageModel
    {
        private readonly PrzepisyContext _context;
        private readonly ILogger<DodawaniePrzepisuModel> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        [BindProperty]
        public Przepis Przepis { get; set; }

        public DodawaniePrzepisuModel(ILogger<DodawaniePrzepisuModel> logger, PrzepisyContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (_signInManager.IsSignedIn(HttpContext.User))
            {
                if (ModelState.IsValid)
                {
                    Przepis.UName = _userManager.GetUserName(HttpContext.User);
                    Przepis.Data = DateTime.Now;
                    _context.Przepis.Add(Przepis);
                    _context.SaveChanges();
                }
            }
        }
    }
}
