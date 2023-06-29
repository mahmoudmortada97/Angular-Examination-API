using ExaminationAuthentication.Models;

namespace ExaminationAuthentication.Repositories.GradeRepository
{
    public interface IGradeRepository
    {
        List<Student_Exam> GetStudentGrade(string studentId);
        Student_Exam GetStudentGradeByStudentIdAndExamId(string studentId, int ExamId);

        void AddGrade(Student_Exam student_Exam);
        void EditGrade(Student_Exam student_Exam);

        List<Student_Exam> GetStudentsGradeByExamID(int ExamId);

    }
}
