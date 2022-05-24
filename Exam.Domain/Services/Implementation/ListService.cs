using Exam.Data.Entities;
using Exam.Data.Enums;
using Exam.Data.Infrastructure;
using Exam.Domain.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Implementation
{
    public class ListService : IListService
    {
        private readonly IStudentService studentService;
        private readonly IGroupService groupService;
        private readonly IRepository<List> listRepository;

        public ListService(
            IStudentService studentService,
            IGroupService groupService,
            IRepository<List> listRepository
            )
        {
            this.studentService = studentService;
            this.groupService = groupService;
            this.listRepository = listRepository;
        }

        public async Task<(bool isSuccessful, List createdList)> CreateExpulsionListAsync(int groupId)
        {
            var students = await studentService.GetByGroupAsync(groupId);
            var expulsedStudents = students
                .Where(s => s.IsExpulsed == true
                && s.InExpulsionList == false)
                .ToList();

            if(expulsedStudents is not null)
            {
                var group = await groupService.GetByIdAsync(groupId);
                var expulsionList = new List
                {
                    ListType = ListTypes.ExpulsionList,
                    GroupName = group.Name,
                    Students = expulsedStudents,
                    CreatedAt = DateTime.Today
                };

                await listRepository.AddAsync(expulsionList);
                await listRepository.SaveChangesAsync();

                return (true, expulsionList);
            }

            return (false, null);
        }
    }
}
