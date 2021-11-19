using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBooklet.Models
{
    public class Ingredients
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Amount")]
        [StringLength(50)]
        public string Amount { get; set; }




    }
}
