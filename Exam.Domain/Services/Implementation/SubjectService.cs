using Exam.Data.Entities;
using Exam.Data.Infrastructure;
using Exam.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Implementation
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> subjectRepository;
        private readonly IRepository<Data.Entities.Exam> examRepository;
        public SubjectService(
            IRepository<Subject> subjectRepository,
            IRepository<Data.Entities.Exam> examRepository
            )
        {
            this.subjectRepository = subjectRepository;
            this.examRepository = examRepository;
        }

        public async Task<(bool isSuccessful, List<Subject>)> GetByGroupAsync(int id)
        {
            var subjects = await examRepository
                .Query()
                .Where(e => e.GroupId == id)
                .Select(e => e.Subject)
                .ToListAsync();

            if(subjects is not null)
            {
                return (true, subjects);
            }
            
            return (false, null);
        }
    }
}
