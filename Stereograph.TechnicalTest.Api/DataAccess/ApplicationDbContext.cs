namespace Stereograph.TechnicalTest.Api.DataAccess;

using Microsoft.EntityFrameworkCore;

/// <summary>
/// Class of the db context
/// </summary>
public class ApplicationDbContext : DbContext
{
    /// <summary>
    /// Dbset of <see cref="Entities.Person"/>
    /// </summary>
    public DbSet<Entities.Person> Persons { get; set; }

    /// <summary>
    /// Constructor of <see cref="ApplicationDbContext"/>
    /// </summary>
    /// <param name="options">Db context options.</param>
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PersonEntityTypeConfiguration());
    }
}
