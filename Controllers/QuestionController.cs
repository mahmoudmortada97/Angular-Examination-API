using ExaminationAuthentication.DTO;
using ExaminationAuthentication.Models;
using ExaminationAuthentication.Repositories.ExamRepository;
using ExaminationAuthentication.Repositories.QuestionRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        IExamRepository _examRepository;
        IQuestionRepository _questionRepository;

        public QuestionController(IExamRepository examRepository, IQuestionRepository questionRepository)
        {
            _examRepository = examRepository;
            _questionRepository = questionRepository;
        }

        [HttpGet("{id}")]
        public ActionResult GetAllByExamId(int id)
        {
            var quests = _questionRepository.GetAll().Where(q => q.ExamId == id).Select(
                q => new QuestionDTO
                {
                    Id = q.Id,
                    Title = q.Title,
                    ExamId = id,
                    //ExamName = _examRepository.GetById(id).Name,
                    Answer = q.Answer,
                    Choice1 = q.Choice1,
                    Choice2 = q.Choice2,
                    Choice3 = q.Choice3,
                    Choice4 = q.Choice4,
                });
            //if (!quests.Any())
            //    return NoContent();
            return Ok(quests);
        }
        [HttpPost]
        public ActionResult Post(QuestionDTO QuestionDTO)
        {
            if (QuestionDTO == null)
                return BadRequest();
            var quest = new Question
            {
                Id = QuestionDTO.Id,
                Title = QuestionDTO.Title,
                Answer = QuestionDTO.Answer,

                Choice1 = QuestionDTO.Choice1,
                Choice2 = QuestionDTO.Choice2,
                Choice3 = QuestionDTO.Choice3,
                Choice4 = QuestionDTO.Choice4,
                ExamId = QuestionDTO.ExamId

            };
            _questionRepository.Create(quest);
            return Ok(quest);
        }


        [HttpPut("{id}")]
        public ActionResult Edit(QuestionDTO QuestionDTO)
        {
            if (_questionRepository == null)
            {
                return BadRequest();
            }
            Question question = _questionRepository.GetById(QuestionDTO.Id);

            question.Title = QuestionDTO.Title;
            question.Answer = QuestionDTO.Answer;
            question.Choice1 = QuestionDTO.Choice1;
            question.Choice2 = QuestionDTO.Choice2;
            question.Choice3 = QuestionDTO.Choice3;
            question.Choice4 = QuestionDTO.Choice4;
            question.ExamId = QuestionDTO.ExamId;


            _questionRepository.Edit(question);
            return Ok(question);
        }

        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            Question question = _questionRepository.GetById(Id);
            if (question == null)
            {
                return NotFound();
            }
            _questionRepository.Delete(Id);
            return Ok(question);
        }
    }
}
