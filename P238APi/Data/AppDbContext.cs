using Microsoft.EntityFrameworkCore;
using P238MovieAPi.Configuration;
using P238MovieAPi.Entities;

namespace P238MovieAPi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { } 
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
