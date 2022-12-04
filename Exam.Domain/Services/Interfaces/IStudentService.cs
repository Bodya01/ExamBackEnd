using Exam.Data.Entities;
using Exam.Domain.Dto.UserDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Student> GetByIdAsync(string id);
        Task<List<Student>> GetByGroupAsync(int id);
        Task<(bool isSuccessful, Student updatedStudent)> ExpulseAsync(string id);
        Task<List<Student>> GetExpulsedStudentsAsync();
        Task<(bool isSuccessful, Student updatedStudent)> ChageAccountAsync(ChangeAccountDto changeAccount);
        Task<(bool isSuccessful, Mark mark)> AddSubjectAsync(AddSubjectDto addSubject);
    }
}
