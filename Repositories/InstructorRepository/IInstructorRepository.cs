using ExaminationAuthentication.Models;

namespace ExaminationAuthentication.Repositories.InstructorRepository
{
    public interface IInstructorRepository
    {
        Instructor GetStudentById(string id);

        void Create(Instructor instructor);
    }
}
