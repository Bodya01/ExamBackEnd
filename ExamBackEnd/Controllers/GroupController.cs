using Exam.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exam.WebApi.Controllers
{
    [Authorize]
    [Route("api/groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;
        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGroups() =>
            Ok(await groupService.GetGroupsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await groupService.GetByIdAsync(id));

        [HttpGet("by-teacher/{id}")]
        public async Task<IActionResult> GetByTeacherId(string id)
        {
            var (isSucessful, groups) = await groupService.GetByTeacherAsync(id);
            return isSucessful ? Ok(groups) : Forbid();
        }
            
    }
}
