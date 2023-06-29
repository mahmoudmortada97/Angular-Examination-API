using ExaminationAuthentication.DTO;
using ExaminationAuthentication.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ExaminationAuthentication.Repositories.ExamRepository
{
    public class ExamRepository : IExamRepository
    {
        AppDbContext _appDbContext;

        public ExamRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Exam> GetAll()
        {
            return _appDbContext.Exams.ToList();
        }

        public Exam GetById(int id)
        {
            return _appDbContext.Exams.FirstOrDefault(e => e.Id == id)!;
        }
        public async void Create(Exam exam)
        {
            _appDbContext.Exams.Add(exam);
            _appDbContext.SaveChanges();
        }

        public async void CreateByQuestion(ExamQuestionsDTO? examDto)
        {
            var exam = new Exam
            {
                Name = examDto.Name,
                Image = examDto.Image,
                Description = examDto.Description,
                questions = examDto.Questions
            };
            //var quests = examDto.Questions.ToList();
            using var transaction = _appDbContext.Database.BeginTransaction();
            try
            {

                //ListQuestion quest;
                //foreach (var q in quests)
                //{
                //    quest = new Question
                //    {
                //        Title = q.Title,
                //        Choice1 = q.Choice1,
                //        Choice2 = q.Choice2,
                //        Choice3 = q.Choice3,
                //        Choice4 = q.Choice4,
                //        Answer = q.Answer,
                //        ExamId= examById.Id as Exam
                //    };

                //}
                await _appDbContext.Exams.AddAsync(exam);
                await _appDbContext.SaveChangesAsync();
                // Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
                transaction.Commit();
            }
            catch (Exception)
            {
                // TODO: Handle failure
            }
        }

        public void Edit(Exam exam)
        {
            _appDbContext.Entry(exam).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            ;
            _appDbContext.Exams.Remove(_appDbContext.Exams.Find(id));
            _appDbContext.SaveChanges();
        }



    }
}
