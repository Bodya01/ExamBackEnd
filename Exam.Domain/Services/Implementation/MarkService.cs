
using Exam.Data.Entities;
using Exam.Data.Infrastructure;
using Exam.Domain.Dto;
using Exam.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Implementation
{
    public class MarkService : IMarkService
    {
        private readonly IRepository<Mark> markRepository;

        public MarkService(
            IRepository<Mark> markRepository
            )
        {
            this.markRepository = markRepository;
        }

        public Task<List<Mark>> GetByStudentAsync(string studentId) =>
            markRepository
                .Query()
                .Where(m => m.StudentId == studentId)
                .Include(m => m.Subject)
                .Include(m => m.Student)
                .ToListAsync();

        public async Task<(bool isSuccessful, Mark updatedMark)> UpdateMarkAsync(MarkDto mark)
        {
            var markToUpdate = await markRepository.GetByIdAsync(mark.Id);

            if(mark is not null)
            {
                markToUpdate.PartialMark = mark.PartialMark;
                markToUpdate.ExamMark = mark.ExamMark;
                markToUpdate.TotalMark = mark.TotalMark;
                markToUpdate.IsConfirmed = mark.IsConfirmed;
                
                await markRepository.UpdateAsync(markToUpdate);
                await markRepository.SaveChangesAsync();

                return (true, markToUpdate);
            }

            return (false, null);
        }
    }
}
