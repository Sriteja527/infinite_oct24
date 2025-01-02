using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace mvcmoviesassesment.Models
{
    public class MoviesDbContext
    {
        public DbSet<Movie1> Movies { get; set; }
    }
}