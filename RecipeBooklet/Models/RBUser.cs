using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBooklet.Models
{
    public class RBUser : IdentityUser
    {
        [Required]
        [DisplayName("First Name")]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(40)]
        public string LastName { get; set; }

        [NotMapped]
        [DisplayName("Full Name")]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        //image properties
        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile ImageFile { get; set; }

        [DisplayName("FileName")]
        public string FileName { get; set; }

        public byte[] FileData { get; set; }



        public virtual ICollection<RecipeBook> RecipeBooks { get; set; } = new HashSet<RecipeBook>();


    }
}
