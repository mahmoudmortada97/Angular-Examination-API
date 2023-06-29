namespace ExaminationAuthentication.Models
{
    public class Student_Exam
    {
        public string StudentId { get; set; }
        public Student Student { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int Grade { get; set; }
    }
}
