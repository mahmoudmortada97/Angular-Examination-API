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
    public class ExamController : ControllerBase
    {
        IExamRepository _examRepository;
        IQuestionRepository _questionRepository;

        public ExamController(IExamRepository examRepository, IQuestionRepository questionRepository)
        {
            _examRepository = examRepository;
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            List<Exam> exams = _examRepository.GetAll();
            List<ExamQuestionsDTO> examDTO = new List<ExamQuestionsDTO>();

            foreach (var exam in exams)
            {
                List<Question> questions = _questionRepository.GetByExamId(exam.Id);

                ExamQuestionsDTO examDTOItem = new ExamQuestionsDTO();

                examDTOItem.Id = exam.Id;
                examDTOItem.Name = exam.Name;
                examDTOItem.Image = exam.Image;
                examDTOItem.Questions = questions;
                examDTOItem.Description = exam.Description;

                examDTO.Add(examDTOItem);
            }

            return Ok(examDTO);
        }



        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            Exam exam = _examRepository.GetById(id);
            List<Question> questions = _questionRepository.GetByExamId(exam.Id);
            List<QuestionDTO> questionsDTO = new List<QuestionDTO>();

            foreach (var item in questions)
            {
                QuestionDTO questionDTOItem = new QuestionDTO()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Choice1 = item.Choice1,
                    Choice2 = item.Choice2,
                    Choice3 = item.Choice3,
                    Choice4 = item.Choice4,
                    Answer = item.Answer,
                };
                questionsDTO.Add(questionDTOItem);

            }

            if (questionsDTO == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(questionsDTO);

            }
        }

        [HttpGet("getexam/{id}")]
        public ActionResult GetExamById(int id)
        {
            if (id == null)
                return BadRequest();
            Exam exam = _examRepository.GetById(id);
            if (exam == null)
                return NotFound();
            ExamDTO examDTO = new ExamDTO
            {
                Id = exam.Id,
                Name = exam.Name,
                Image = exam.Image,
                Description = exam.Description,
            };
            return Ok(examDTO);
        }
        [HttpPost]
        public ActionResult Post(ExamDTO examDTO)
        {
            if (examDTO == null)
                return BadRequest();
            var exam = new Exam
            {
                Name = examDTO.Name,
                Description = examDTO.Description,
                Image = examDTO.Image,
            };
            _examRepository.Create(exam);
            return Ok(exam);
        }
        [HttpPost("PostByQuestion")]
        public ActionResult PostByQuestion(ExamQuestionsDTO? examDto)
        {
            if (examDto == null)
                return BadRequest();
            else
            {

                _examRepository.CreateByQuestion(examDto);
                return Ok(examDto);
            }

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest();
            Exam exam = _examRepository.GetById(id);
            if (exam == null)
            {
                return NotFound();
            }
            _examRepository.Delete(id);
            return Ok(exam);
        }

        [HttpPut("{id}")]
        public ActionResult Edit(ExamDTO examDTO, int id)
        {
            if (examDTO == null)
                return BadRequest();
            Exam exam = new Exam
            {
                Id = id,
                Name = examDTO.Name,
                Description = examDTO.Description,
                Image = examDTO.Image,
            };
            _examRepository.Edit(exam);
            return Ok(examDTO);
        }
    }
}
