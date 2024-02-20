namespace Stereograph.TechnicalTest.Api.DataAccess;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// Entity configuration for <see cref="Entities.Person"/>.
/// </summary>
public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<Entities.Person>
{
    public void Configure(EntityTypeBuilder<Entities.Person> builder)
    {
        builder.ToTable("Persons");
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Reference).HasColumnName("reference").HasColumnType("int").ValueGeneratedOnAdd();
        builder.Property(p => p.FirstName).HasColumnName("firstName").HasColumnType("nvarchar");
        builder.Property(p => p.LastName).HasColumnName("lastName").HasColumnType("nvarchar");
        builder.Property(p => p.Email).HasColumnName("email").HasColumnType("nvarchar");
        builder.Property(p => p.Address).HasColumnName("address").HasColumnType("nvarchar");
    }
}
