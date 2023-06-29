using ExaminationAuthentication.Models;

namespace ExaminationAuthentication.Repositories.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        AppDbContext _appDbContext;

        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Create(Student student)
        {
            _appDbContext.Students.Add(student);
            _appDbContext.SaveChanges();
        }

        public Student GetStudentById(string id)
        {
            return _appDbContext.Students.SingleOrDefault(s => s.Id == id)!;
        }
    }
}
