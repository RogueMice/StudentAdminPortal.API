using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DTO;
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

        [HttpPost("add_student")]
        public async Task<IActionResult> AddStudent([FromBody] StudentViewDTO dto)
        {
            var newStudent = await studentService.AddAsync(dto);
            return Ok(new
            {
                messenger = "add sucessfully !",
                result = newStudent
            });
        }

        [HttpPatch("update_student/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudent(Guid studentId, [FromBody] StudentViewDTO dto)
        {
            var updatedStudent = await studentService.UpdateAsync(studentId, dto);
            return Ok(new
            {
                messenger = "update sucessfully !",
                result = updatedStudent
            });
        }

        [HttpDelete("delete_student/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            var deletedStudentId = await studentService.DeleteAsync(studentId);
            return Ok(new
            {
                messenger = "delete sucessfully !",
                result = deletedStudentId
            });
        }
    }
}
