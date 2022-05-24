﻿using Exam.Domain.Services.Interfaces;
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
    }
}
