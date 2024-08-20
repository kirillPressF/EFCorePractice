using CSharpFunctionalExtensions;

namespace EFCorePractice.Entitites
{
    public class Course : Entity
    {
        public static readonly Course Math = new(1, "Math");
        public static readonly Course Chemistry = new(2, "Chemistry");

        public static readonly Course[] AllCourses = [Math, Chemistry];

        public string Name { get; } = null!;

        public static Result<Course> FromId(long id)
        {
            var course = AllCourses.SingleOrDefault(c => c.Id == id);
            return course is null ? Result.Failure<Course>("course not found") : course;
        }
        private Course() { }
        private Course(long id, string name) : base(id)
        {
            Name = name;
        }
    }
}
