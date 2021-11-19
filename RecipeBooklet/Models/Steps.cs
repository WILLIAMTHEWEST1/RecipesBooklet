using RecipeBooklet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBooklet.Models
{
    public class Steps
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(500)]
        public string Description { get; set; }

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }




}
