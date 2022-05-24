using Exam.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exam.WebApi.Controllers
{
    [Authorize]
    [Route("api/subjects")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;

        public SubjectController(
            ISubjectService subjectService
            )
        {
            this.subjectService = subjectService;
        }

        [HttpGet("by-group/{id}")]
        public async Task<IActionResult> GetSubjectsByGroup(int id)
        {
            var (isSuccessful, subjects) = await subjectService.GetByGroupAsync(id);
            return isSuccessful ? Ok(subjects) : Forbid();
        }
    }
}
