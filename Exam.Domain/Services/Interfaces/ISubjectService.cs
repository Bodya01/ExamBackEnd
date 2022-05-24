using Exam.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<(bool isSuccessful, List<Subject>)> GetByGroupAsync(int id);
    }
}
