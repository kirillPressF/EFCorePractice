using EFCorePractice.Database;
using EFCorePractice.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCorePractice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        protected private readonly ApplicationDbContext _dbcontext;
        public StudentController(ApplicationDbContext context)
        {
            _dbcontext = context;
        }
        [HttpPost]
        public async Task<ActionResult<string>> RegisterStudent(string firstName, string lastName, long favoriteCourseId, Grade FavoriteCourseGrade)
        {
            var nameResult = Name.Create(firstName, lastName);
            if(nameResult.IsFailure)
            {
                return BadRequest(nameResult.Error);
            }
            var courseResult = Course.FromId(favoriteCourseId);
            if (courseResult.IsFailure)
            {
                return BadRequest(courseResult.Error);
            }
            var student = new Student(nameResult.Value, courseResult.Value);

            var enrollment = new Enrollment(courseResult.Value, student, FavoriteCourseGrade);

            student.Enrollments.Add(enrollment);

            _dbcontext.Students.Add(student);

            var entries = _dbcontext.ChangeTracker.Entries();

            await _dbcontext.SaveChangesAsync();

            return Ok("student successfully registered");
        }
    }
}