using Microsoft.EntityFrameworkCore;
using Reax.Data.Entities;

namespace Reax.Data.ReaxContext
{
    public interface IReaxDatabaseContext
    {
        DbSet<Movie> Movies { get; set; }
    }
}
