using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RecipeBooklet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBooklet.Models
{
    public class RecipeBook 
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Book Name")]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(500)]
        public string Description { get; set; }


        public int RecipeId { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();





    }
}
