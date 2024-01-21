using Microsoft.EntityFrameworkCore;

namespace AnnonsWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Annons> Annonser { get; set; }

    }
}
