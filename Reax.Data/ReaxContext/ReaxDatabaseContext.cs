using System.Linq;
using Microsoft.EntityFrameworkCore;
using Reax.Data.Entities;
using Reax.Data.SampleData;

namespace Reax.Data.ReaxContext
{
    public class ReaxDatabaseContext : DbContext, IReaxDatabaseContext
    {
        public ReaxDatabaseContext(DbContextOptions<ReaxDatabaseContext> options)
            : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var sampleMovies = new SampleDataBuilder().GetSampleData();
            sampleMovies.ForEach(movie => modelBuilder.Entity<Movie>().HasData(movie));

        }
    }
}
