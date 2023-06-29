namespace ExaminationAuthentication.Models
{
    public class Instructor
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Exam>? Exams { get; set; } = new List<Exam> { };
    }
}
