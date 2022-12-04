using Exam.Data.Entities;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Interfaces
{
    public interface IListService
    {
        Task<(bool isSuccessful, List createdList)> CreateExpulsionListAsync(int groupId);
    }
}
