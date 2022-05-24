using Exam.Data.Entities;
using Exam.Data.Infrastructure;
using Exam.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Data.Entities.Group> groupRepository;
        private readonly IRepository<Teacher> teacherRepository;
        private readonly IRepository<Data.Entities.Exam> examRepository;

        public GroupService(
            IRepository<Data.Entities.Group> groupRepository,
            IRepository<Teacher> teacherRepository,
            IRepository<Data.Entities.Exam> examRepository
            )
        {
            this.groupRepository = groupRepository;
            this.teacherRepository = teacherRepository;
            this.examRepository = examRepository;
        }

        public Task<List<Data.Entities.Group>> GetGroupsAsync() =>
            groupRepository.Query().ToListAsync();

        public async Task<Group> GetByIdAsync(int id) =>
            await groupRepository.GetByIdAsync(id);

        public async Task<(bool isSuccessful, List<Group> teacherGroups)> GetByTeacherAsync(string teacherId)
        {
            var teacher = await teacherRepository.GetByIdAsync(teacherId);

            if(teacher is not null)
            {
                var groups = await examRepository
                    .Query()
                    .Where(e => e.Subject.Teachers.Contains(teacher))
                    .Select(e => e.Group)
                    .ToListAsync();

                return (true, groups);
            }

            return (false, null);
        }
    }
}
