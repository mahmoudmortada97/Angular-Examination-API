using ExaminationAuthentication.Models;
using Microsoft.EntityFrameworkCore;

namespace ExaminationAuthentication.Repositories.GradeRepository
{
    public class GradeRepository : IGradeRepository
    {
        AppDbContext _appDbContext;

        public GradeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void AddGrade(Student_Exam student_Exam)
        {
            _appDbContext.Add(student_Exam);
            _appDbContext.SaveChanges();
        }

        public void EditGrade(Student_Exam student_Exam)
        {
            _appDbContext.Entry(student_Exam).State = EntityState.Modified;
            _appDbContext.SaveChanges();
        }

        public List<Student_Exam> GetStudentGrade(string studentId)
        {
            return _appDbContext.Students_Exams.Where(se => se.StudentId == studentId).ToList();
        }

        public Student_Exam GetStudentGradeByStudentIdAndExamId(string studentId, int ExamId)
        {
            return _appDbContext.Students_Exams.FirstOrDefault(se => se.ExamId == ExamId && se.StudentId == studentId)!;
        }

        public List<Student_Exam> GetStudentsGradeByExamID(int ExamId)
        {
            return _appDbContext.Students_Exams.Where(se=>se.ExamId ==ExamId).Include(se=>se.Student).ToList();
        }
    }
}
