using ExaminationAuthentication.Models;

namespace ExaminationAuthentication.Repositories.QuestionRepository
{
    public interface IQuestionRepository
    {
        List<Question> GetAll();
        Question GetById(int id);

        List<Question> GetByExamId(int examID);
        void Create(Question question);
        void Edit(Question question);
        void Delete(int id);
    }
}
