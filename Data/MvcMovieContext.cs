using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public DbSet<Movie> Movie { get; set; }

        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public void Migrate()
        {
            Database.Migrate();
        }

        public void InitData(List<Movie> data)
        {
            if (Movie.Any())
            {
                return;
            }
            Movie.AddRange(data);
            SaveChanges();
        }
    }
}