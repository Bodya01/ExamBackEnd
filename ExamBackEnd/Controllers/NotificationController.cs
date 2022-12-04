using Exam.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exam.WebApi.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;

        public NotificationController(
            INotificationService notificationService
            )
        {
            this.notificationService = notificationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUser(string id) =>
            Ok(await notificationService.GetByUserAsync(id));

        [HttpGet("check")]
        public async Task<IActionResult> CheckUsers()
        {
            await notificationService.CheckUsersForExamNotification();
            return Ok("Success!");
        }
    }
}
