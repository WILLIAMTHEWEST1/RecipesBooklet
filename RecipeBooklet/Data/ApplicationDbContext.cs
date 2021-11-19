using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using RecipeBooklet.Models;

namespace RecipeBooklet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeBook> RecipeBook { get; set; }
        public DbSet<RecipeBooklet.Models.Steps> Steps { get; set; }
    }
}
