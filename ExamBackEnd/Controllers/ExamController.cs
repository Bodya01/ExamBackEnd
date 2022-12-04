using Exam.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exam.WebApi.Controllers
{
    [Authorize]
    [Route("api/exams")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IExamService examService;

        public ExamController(
            IExamService examService
        )
        {
            this.examService = examService;
        }

        [HttpGet("by-group/{id}")]
        public async Task<IActionResult> GetExamsByGroup(int id) =>
            Ok(await examService.GetByGroupAsync(id));

        [HttpGet("by-teacher/{id}")]
        public async Task<IActionResult> GetExamsByTeacher(string id) =>
            Ok(await examService.GetByTeacherAsync(id));

        [HttpGet("by-student/{id}")]
        public async Task<IActionResult> GetExamsByStudent(string id) =>
            Ok(await examService.GetByStudentAsync(id));
    }
}
