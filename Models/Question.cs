using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExaminationAuthentication.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public string Answer { get; set; }


        [JsonIgnore]

        [ForeignKey("Exam")]
        public int? ExamId { get; set; }
        [JsonIgnore]

        public Exam? Exam { get; set; }
    }
}
