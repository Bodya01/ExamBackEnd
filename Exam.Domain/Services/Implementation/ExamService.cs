using Exam.Data.Entities;
using Exam.Data.Infrastructure;
using Exam.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Implementation
{
    public class ExamService : IExamService
    {
        private readonly IRepository<Data.Entities.Exam> examRepository;
        private readonly IRepository<Teacher> teacherRepository;
        private readonly IRepository<Student> studentRepository;

        public ExamService(
            IRepository<Data.Entities.Exam> examRepository,
            IRepository<Teacher> teacherRepository,
            IRepository<Student> studentRepository
            )
        {
            this.examRepository = examRepository;
            this.teacherRepository = teacherRepository;
            this.studentRepository = studentRepository;
        }

        public Task<List<Data.Entities.Exam>> GetByGroupAsync(int groupId) =>
            examRepository
                .Query()
                .Include(e => e.Subject)
                    .ThenInclude(s => s.Teachers)
                .Where(e => e.Id == groupId)
                .OrderBy(e => e.ExamDate)
                .ToListAsync();
        
        public async Task<List<Data.Entities.Exam>> GetByTeacherAsync(string id)
        {
            var teacher = await teacherRepository.GetByIdAsync(id);

            return await examRepository
                .Query()
                .Where(e => e.Subject.Teachers.Contains(teacher))
                .Include(e => e.Group)
                .Include(e => e.Subject)
                    .ThenInclude(e => e.Teachers)
                .OrderBy(e => e.ExamDate)
                .ToListAsync();
        }

        public async Task<List<Data.Entities.Exam>> GetByStudentAsync(string id)
        {
            var student = await studentRepository.GetByIdAsync(id);

            return await examRepository
                .Query()
                .Where(e => e.Group.Students.Contains(student))
                .Include(e => e.Group)
                .Include(e => e.Subject)
                .ToListAsync();
        }
    }
}
