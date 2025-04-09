using Microsoft.AspNetCore.Mvc;
using WebApiDocker.Services.Interface;

namespace WebApiDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(Guid id)
        {
            try
            {
                var student = _studentService.GetStudentById(id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Dtos.StudentRequestDto studentRequestDto)
        {
            if (studentRequestDto == null)
            {
                return BadRequest("Student data is null");
            }
            _studentService.AddStudent(studentRequestDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Guid id, [FromBody] Dtos.StudentRequestDto studentRequestDto)
        {
            if (studentRequestDto == null)
            {
                return BadRequest("Student data is null");
            }
            try
            {
                _studentService.UpdateStudent(id, studentRequestDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(Guid id)
        {
            try
            {
                _studentService.DeleteStudent(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
