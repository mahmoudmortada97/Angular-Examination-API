using ExaminationAuthentication.Models;

namespace ExaminationAuthentication.DTO
{
    public class ExamQuestionsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
    }
}
