namespace ExaminationAuthentication.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Student_Exam>? student_Exams { get; set; } = new List<Student_Exam> { };

    }
}
