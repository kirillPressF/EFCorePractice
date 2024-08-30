using EFCorePractice.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Primitives;

namespace EFCorePractice.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> studentBuilder)
        {
            studentBuilder.ToTable("Students").HasKey(student => student.Id);
            studentBuilder.Property(student => student.Id).HasColumnName("StudentID");
            studentBuilder.ComplexProperty(student => student.Name, nameBuilder =>
            {
                nameBuilder.Property(name => name.FirstName).HasColumnName("Firstname").HasMaxLength(150);
                nameBuilder.Property(name => name.LastName).HasColumnName("Lastname").HasMaxLength(100);
            });
            studentBuilder.HasOne(student => student.FavoriteCourse)
            .WithMany();
            studentBuilder.HasMany(student => student.Enrollments)
            .WithOne(enrollment => enrollment.Student);
        }

    }
}
