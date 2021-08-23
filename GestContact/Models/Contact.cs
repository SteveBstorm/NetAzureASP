using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestContact.Models
{
    public class Contact
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nom de famille")]
        public string LastName { get; set; }
        [DataType(DataType.Password)]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
   
        public string Email { get; set; }
        public bool IsFavorite { get; set; }
    }
}
