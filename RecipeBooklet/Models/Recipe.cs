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
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Title")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(500)]
        public string Description { get; set; }

        //image properties
        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }

        [DisplayName("FileName")]
        public string FileName { get; set; }

        public byte[] FileData { get; set; }


        public int RBuserId { get; set; }
        public int IngredientsId { get; set; }
        public int StepsId { get; set; }


        public virtual ICollection<RBUser> RBUsers { get; set; } = new HashSet<RBUser>();

        public virtual ICollection<Ingredients> Ingredients { get; set; } = new HashSet<Ingredients>();

        public virtual ICollection<Steps> Steps { get; set; } = new HashSet<Steps>();
    }
}
