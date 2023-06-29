using ExaminationAuthentication.DTO;
using ExaminationAuthentication.Models;
using ExaminationAuthentication.Repositories.ExamRepository;
using ExaminationAuthentication.Repositories.GradeRepository;
using ExaminationAuthentication.Repositories.StudentRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExaminationAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        IGradeRepository _gradeRepository;
        IStudentRepository _studentRepository;
        IExamRepository _examRepository;
        public GradeController(IGradeRepository gradeRepository,

        IStudentRepository studentRepository,
        IExamRepository examRepository)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
            _examRepository = examRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Student_Exam>> GetStudentGrades(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            List<Student_Exam> student_Exams = _gradeRepository.GetStudentGrade(id);

            return Ok(student_Exams);
        }

        [HttpGet("{ExamId}")]
        public async Task<ActionResult<Student_Exam>> GetStudentGradesByExamId(int ExamId)
        {
            if (ExamId == null)
            {
                return BadRequest();
            }
            List<Student_Exam> student_Exams = _gradeRepository.GetStudentsGradeByExamID(ExamId);

            List<StudentsGradesDTO> studentGrades = new List<StudentsGradesDTO>();

            foreach (var item in student_Exams)
            {
                StudentsGradesDTO studentsGradesItem = new StudentsGradesDTO
                {
                    StudentEmail = item.Student.Email,
                    Grade = item.Grade

                };
                studentGrades.Add(studentsGradesItem);
            }

            return Ok(studentGrades);
        }

        [HttpGet("students/{studentId}/exams/{examId}")]
        public async Task<ActionResult> GetStudentGradeInExam(string studentId, int examId)
        {
            if (studentId == null || examId == null)
            {
                return BadRequest();
            }
            Student_Exam student_Exam = _gradeRepository.GetStudentGradeByStudentIdAndExamId(studentId, examId);

            return Ok(student_Exam);
        }

        [HttpPost]
        public async Task<ActionResult<Student_Exam>> PostStudentGrade(StudentGrade StudentGradeDTO)
        {
            if (StudentGradeDTO == null)
            {
                return BadRequest();
            }
            Student_Exam student_Exam = new Student_Exam()
            {
                ExamId = StudentGradeDTO.ExamId,
                StudentId = StudentGradeDTO.StudentId,
                Grade = StudentGradeDTO.Grade,

            };
            _gradeRepository.AddGrade(student_Exam);

            return CreatedAtAction("GetStudentGrades", new { id = student_Exam.StudentId }, student_Exam);
        }

        [HttpPut("students/{studentId}/exams/{examId}")]
        public async Task<IActionResult> PutDepartment(string studentId, int examId, StudentGrade StudentGradeDTO)
        {

            var student = _studentRepository.GetStudentById(studentId);
            if (student == null)
            {
                return NotFound($"Student with ID {studentId} not found.");
            }

            var exam = _examRepository.GetById(examId);
            if (exam == null)
            {
                return NotFound($"Exam with ID {examId} not found.");
            }
            Student_Exam student_Exam = _gradeRepository.GetStudentGradeByStudentIdAndExamId(studentId, examId);
            if (student_Exam == null)
            {
                return NotFound($"Student {student.Email}  didnot Take Exam {exam.Name}");
            }
            student_Exam.Grade = StudentGradeDTO.Grade;
            _gradeRepository.EditGrade(student_Exam);
            return NoContent();
        }
    }
}
