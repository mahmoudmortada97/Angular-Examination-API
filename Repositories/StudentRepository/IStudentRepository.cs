using ExaminationAuthentication.Models;

namespace ExaminationAuthentication.Repositories.StudentRepository
{
    public interface IStudentRepository
    {
        Student GetStudentById(string id);

        void Create (Student student);

    }
}
