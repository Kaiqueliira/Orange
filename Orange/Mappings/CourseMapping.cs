using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orange.Model;

namespace Orange.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Course");

            builder.HasKey(c => c.Id);
            builder.Property(p => p.Type)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Author)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Link)
                .HasColumnType("varchar")
                .IsRequired();

            builder.HasOne(t => t.Trail)
                .WithMany(c => c.Courses)
                .HasForeignKey(c => c.TrailId)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
