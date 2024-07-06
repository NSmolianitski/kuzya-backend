using KuzyaBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace KuzyaBackend;

public class ApplicationDbContext : DbContext
{
    public DbSet<Ingredient> Ingredients { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}