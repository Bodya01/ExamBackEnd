using Exam.Data.Entities;
using Exam.Domain.Dto;
using Exam.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exam.WebApi.Controllers
{
    [Authorize]
    [Route("api/marks")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private readonly IMarkService markService;

        public MarkController(
            IMarkService markService
            )
        {
            this.markService = markService;
        }

        [HttpGet("by-student/{id}")]
        public async Task<IActionResult> GetMarksByStudentAndSubject(string id) =>
                Ok(await markService.GetByStudentAsync(id));

        [HttpPut("update/")]
        public async Task<IActionResult> UpdateMark(MarkDto mark)
        {
            var (isSuccessful, updatedMark) = await markService.UpdateMarkAsync(mark);
            return isSuccessful ? Ok(updatedMark) : Forbid();
        }
    }
}
