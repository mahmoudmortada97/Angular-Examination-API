using ExaminationAuthentication.DTO;
using ExaminationAuthentication.Models;

namespace ExaminationAuthentication.Repositories.ExamRepository
{
    public interface IExamRepository
    {
        List<Exam> GetAll();
        Exam GetById(int id);

        void Create(Exam exam);
        void CreateByQuestion(ExamQuestionsDTO examDto);

        void Edit(Exam exam);
        void Delete(int id);
    }
}
