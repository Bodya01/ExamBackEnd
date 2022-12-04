using Exam.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Interfaces
{
    public interface IGroupService
    {
        Task<List<Group>> GetGroupsAsync();
        Task<Group> GetByIdAsync(int id);
        Task<(bool isSuccessful, List<Group> teacherGroups)> GetByTeacherAsync(string teacherId);
    }
}
