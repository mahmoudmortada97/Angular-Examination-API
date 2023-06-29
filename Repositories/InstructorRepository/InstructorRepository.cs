using ExaminationAuthentication.Models;

namespace ExaminationAuthentication.Repositories.InstructorRepository
{
    public class InstructorRepository : IInstructorRepository
    {
        AppDbContext _appDbContext;

        public InstructorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Instructor instructor)
        {
            _appDbContext.Instructors.Add(instructor);
            _appDbContext.SaveChanges();
        }

        public Instructor GetStudentById(string id)
        {
            return _appDbContext.Instructors.SingleOrDefault(s => s.Id == id)!;

        }
    }
}
