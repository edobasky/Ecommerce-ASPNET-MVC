using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int id { get; set; }
        [Display(Name ="Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }
        [Display(Name ="Full Name")]
        [Required(ErrorMessage ="Fuul Name is required")]
        [StringLength(50, ErrorMessage ="Full Name must be between 3 and 50 chars")]
        public string FullName { get; set; }
        [Display(Name ="Biography")]
        [Required(ErrorMessage ="Biograpjy is required")]
        public string Bio { get; set; }

        public List<Actor_Movies> Actor_Movies { get; set; }


    }
}
