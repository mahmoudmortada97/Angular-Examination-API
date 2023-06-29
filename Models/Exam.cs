using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationAuthentication.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }


        public List<Question> questions { get; set; } = new List<Question>();
        public List<Student_Exam> student_Exams { get; set; } = new List<Student_Exam> { };


        [ForeignKey("Instructor")]
        public string? InstructorId { get; set; }
        public Instructor? Instructor { get; set; }
    }
}
