using Exam.Data.Entities;
using Exam.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Interfaces
{
    public interface IMarkService
    {
        Task<List<Mark>> GetByStudentAsync(string studentId);
        Task<(bool isSuccessful, Mark updatedMark)> UpdateMarkAsync(MarkDto mark);
    }
}
