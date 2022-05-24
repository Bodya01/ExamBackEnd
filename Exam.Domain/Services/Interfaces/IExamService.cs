using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Interfaces
{
    public interface IExamService
    {
        Task<List<Data.Entities.Exam>> GetByGroupAsync(int groupId);
    }
}
