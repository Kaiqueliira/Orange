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

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Type)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.Author)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Link)
                .HasColumnType("varchar")
                .IsRequired();

            builder.HasOne(p => p.Trail)
                .WithMany(p => p.Courses);


        }
    }
}
