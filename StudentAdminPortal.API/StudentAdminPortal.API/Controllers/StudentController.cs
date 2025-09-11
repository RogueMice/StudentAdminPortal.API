using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.Service.Interface;

namespace StudentAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("get_all_student")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentService.GetAsync();
            return Ok(students);
        }

        [HttpGet("get_student_by_id/{studentId:guid}")]
        public async Task<IActionResult> GetStudentById(Guid studentId)
        {
            var student = await studentService.GetByIdAsync(studentId);
            if (student == null)
                return NotFound("Not found !");
            return Ok(student);
        }
    }
}
