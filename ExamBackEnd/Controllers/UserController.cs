using Exam.Domain.Dto.UserDtos;
using Exam.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exam.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IStudentService studentService;

        public UserController(
            IStudentService studentService
            )
        {
            this.studentService = studentService;
        }

        [HttpPut("change-bank-account")]
        public async Task<IActionResult> ChangeStudentBankAccout(ChangeAccountDto changeAccount)
        {
            var (isSuccessful, updatedStudent) = await studentService.ChageAccountAsync(changeAccount);
            return isSuccessful ? Ok(updatedStudent) : Forbid();
        }

        [HttpGet("students/{id}")]
        public async Task<IActionResult> GetStudentById(string id) =>
            Ok(await studentService.GetByIdAsync(id));

        [HttpGet("students/by-group/{id}")]
        public async Task<IActionResult> GetStudentsByGroup(int id) =>
            Ok(await studentService.GetByGroupAsync(id));

        [HttpPost("students/expulse/{id}")]
        public async Task<IActionResult> Expulse(string id)
        {
            var (isSuccessful, updatedStudent) = await studentService.ExpulseAsync(id);
            return isSuccessful ? Ok(updatedStudent) : Forbid();
        }

        [HttpGet("students/get-expulsed")]
        public async Task<IActionResult> GetExpulsedStudents() =>
            Ok(await studentService.GetExpulsedStudentsAsync());

        [HttpPost("students/add-subject")]
        public async Task<IActionResult> AddSubject(AddSubjectDto addSubject)
        {
            var (isSuccessful, mark) = await studentService.AddSubjectAsync(addSubject);
            return isSuccessful ? Ok(mark) : Forbid();
        }
    }
}
