//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Ulubione.Data;
//using Ulubione.Models;

//namespace Ulubione.Pages
//{
//    public class UlubionePrzepisyModel : PageModel
//    {
//        private readonly PrzepisyContext _context;
//        private readonly UserManager<IdentityUser> _userManager;
//        public UlubionePrzepisyModel(PrzepisyContext context, UserManager<IdentityUser> userManager)
//        {
//            _userManager = userManager;
//            _context = context;
//        }
//        [BindProperty]
//        public UlubioneModel UlubioneModel { get; set; }
//        [BindProperty]
//        public Przepis Przepis { get; set; }
//        public IList<UlubioneModel> Lista { get; set; }
//        public void OnGet()
//        {
//            Lista = _context.UlubioneModel.ToList();
//        }
//    }
//}
