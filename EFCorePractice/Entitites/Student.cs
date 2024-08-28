using CSharpFunctionalExtensions;

namespace EFCorePractice.Entitites
{
    public class Student : Entity
    {
        public Name Name { get; set; } = null!;
        public Course? FavoriteCourse { get; set; }
        public List<Enrollment> Enrollments { get; set; } = [];
        private Student() { }
        private Student(Name name, Course? favoriteCourse)
        {
            Name = name;
            FavoriteCourse = favoriteCourse;
        }
    }
} 