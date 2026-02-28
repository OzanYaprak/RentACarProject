using Domain.Entities;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration _configuration { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration): base(dbContextOptions)
    {
        _configuration = configuration;

        /// • EnsureDeleted() + EnsureCreated() ikilisi yalnızca birim testlerinde veya prototip geliştirmede kullanılır.
        /// • EnsureCreated() Tabloları migration olmadan direkt oluşturur. • EnsureDeleted(): Veritabanını siler.
        //Database.EnsureCreated(); 
    }

    public DbSet<Brand> Brands { get; set;  } = null!;
    public DbSet<Car> Cars { get; set;  } = null!;
    public DbSet<Fuel> Fuels { get; set;  } = null!;
    public DbSet<Model> Models { get; set;  } = null!;
    public DbSet<Transmission> Transmissions { get; set;  } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
