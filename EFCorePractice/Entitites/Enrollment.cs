using CSharpFunctionalExtensions;

namespace EFCorePractice.Entitites
{
    public class Enrollment : Entity
    {
        public Grade Grade { get; set; }
        public Course Course { get; set; } = null!;
        public Student Student { get; set; } = null!;
        private Enrollment() { }
        private Enrollment(long id, Grade grade, Course course, Student student) : base(id)
        {
            Grade = grade;
            Course = course;
            Student = student;
        }
    }
}
