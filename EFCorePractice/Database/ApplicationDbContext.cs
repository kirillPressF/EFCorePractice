using EFCorePractice.Entitites;
using Microsoft.EntityFrameworkCore;

namespace EFCorePractice.Database
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(_configuration.GetConnectionString("DbContext"))
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())) // Log SQL queries to console
                .EnableSensitiveDataLogging();// Log parameters to console

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<Course>(courseBuilder =>
            {
                courseBuilder.ToTable("Courses").HasKey(course => course.Id);
                courseBuilder.Property(course => course.Id).HasColumnName("CourseID");
                courseBuilder.Property(course => course.Name).HasColumnName("Name").HasMaxLength(100);

                courseBuilder.HasData(Course.Math, Course.Chemistry);
            });

            modelBuilder.Entity<Enrollment>(enrollmentBuilder =>
            {
                enrollmentBuilder.ToTable("Enrollments").HasKey(enrollment => enrollment.Id);
                enrollmentBuilder.Property(enrollment => enrollment.Id).HasColumnName("EnrollmentID");
                enrollmentBuilder.HasOne(enrollment => enrollment.Student).WithMany(enrollment => enrollment.Enrollments);
                enrollmentBuilder.HasOne(enrollment => enrollment.Course).WithMany();
            });
        }
    }
} 