using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Exam.WebApi.Controllers
{
    [Route("api/greeting")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        [HttpGet("{number}")]
        public async Task<IActionResult> GetGreetingMessage(int number) =>
            Ok(new Message { MessageText = $"Your number is {number}" });
    }
}
