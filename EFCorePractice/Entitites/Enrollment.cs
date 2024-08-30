using CSharpFunctionalExtensions;

namespace EFCorePractice.Entitites
{
    public class Enrollment : Entity
    {
        public Grade Grade { get; set; }
        public Course Course { get; set; } = null!;
        public Student Student { get; set; } = null!;
        private Enrollment() { }
        public Enrollment(Course course, Student student, Grade grade)
        {
            Course = course;
            Student = student;
            Grade = grade;
        }
    }
}
