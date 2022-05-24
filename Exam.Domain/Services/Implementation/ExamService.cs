using Exam.Data.Infrastructure;
using Exam.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Implementation
{
    public class ExamService : IExamService
    {
        private readonly IRepository<Data.Entities.Exam> examRepository;

        public ExamService(
            IRepository<Data.Entities.Exam> examRepository
            )
        {
            this.examRepository = examRepository;
        }

        public Task<List<Data.Entities.Exam>> GetByGroupAsync(int groupId) =>
            examRepository
                .Query()
                .Include(e => e.Subject)
                .ThenInclude(s => s.Teachers)
                .Where(e => e.Id == groupId)
                .OrderBy(e => e.ExamDate)
                .ToListAsync();
    }
}
