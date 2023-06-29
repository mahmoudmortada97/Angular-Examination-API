using ExaminationAuthentication.Models;
using Microsoft.EntityFrameworkCore;

namespace ExaminationAuthentication.Repositories.QuestionRepository
{
    public class QuestionRepository : IQuestionRepository
    {
        AppDbContext _appDbContext;

        public QuestionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Question> GetAll()
        {
            return _appDbContext.Questions.ToList();
        }

        public List<Question> GetByExamId(int examID)
        {
            return _appDbContext.Questions.Where(q => q.ExamId == examID).ToList();
        }

        public Question GetById(int id)
        {
            return _appDbContext.Questions.FirstOrDefault(e => e.Id == id)!;
        }
        public void Create(Question question)
        {
            _appDbContext.Questions.Add(question);
            _appDbContext.SaveChanges();
        }

        public void Edit(Question question)
        {
            _appDbContext.Entry(question).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Question question = _appDbContext.Questions.FirstOrDefault(q => q.Id == id)!;
            _appDbContext.Questions.Remove(question);
            _appDbContext.SaveChanges();
        }   
    }
}
