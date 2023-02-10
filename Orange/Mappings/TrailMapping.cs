using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orange.Model;

namespace Orange.Mappings
{
    public class TrailMapping : IEntityTypeConfiguration<Trail>
    {
        public void Configure(EntityTypeBuilder<Trail> builder)
        {
            builder.ToTable("Trail");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("varchar(1024)");

        }
    }
}
