using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ulubione.Models
{
    public class Przepis
    {
        [Key]
        public int PrzepisId { get; set; }
        public int Id { get; set; }

        [Display(Name = "Nazwa przepisu:")]
        [StringLength(100, MinimumLength = 3), Required(ErrorMessage = "Pole 'Nazwa' jest obowiązkowe")]
        public string Nazwa { get; set; }

        [Display(Name = "Lista składników:")]
        [StringLength(100, MinimumLength = 20), Required(ErrorMessage = "Pole 'Lista skladnikow' jest obowiązkowe")]
        public string ListaSkladnikow { get; set; }

        [Display(Name = "Opis przepisu:")]
        [Required(ErrorMessage = "Pole 'Opis' jest obowiązkowe")]
        public string Opis { get; set; }

        [Display(Name = "Data publikacji:")]
        public DateTime Data { get; set; }
        public string UName { get; set; }
    }
}
