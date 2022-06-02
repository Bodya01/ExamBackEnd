using Exam.Data.Entities;
using Exam.Data.Infrastructure;
using Exam.Domain.Dto.UserDtos;
using Exam.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> studentRepository;
        private readonly IRepository<Subject> subjectRepository;
        private readonly IRepository<Mark> markRepository;
        public StudentService(
            IRepository<Student> studentRepository,
            IRepository<Subject> subjectRepository,
            IRepository<Mark> markRepository
            )
        {
            this.studentRepository = studentRepository;
            this.subjectRepository = subjectRepository;
            this.markRepository = markRepository;
        }
        public async Task<Student> GetByIdAsync(string id) =>
            await studentRepository.GetByIdAsync(id);

        public Task<List<Student>> GetByGroupAsync(int id) =>
            studentRepository
                .Query()
                .Where(s => s.GroupId == id)
                .ToListAsync();

        public async Task<(bool isSuccessful, Student updatedStudent)> ExpulseAsync(string id)
        {
            var student = await studentRepository.GetByIdAsync(id);

            if(student is not null)
            {
                student.IsExpulsed = true;
                student.ExpulsionDate = DateTime.Today;

                await studentRepository.UpdateAsync(student);
                await studentRepository.SaveChangesAsync();

                return (true, student);
            }
            return (false, null);
        }

        public Task<List<Student>> GetExpulsedStudentsAsync() =>
            studentRepository
                .Query()
                .Where(s => s.IsExpulsed == true)
                .ToListAsync();

        public async Task<(bool isSuccessful, Student updatedStudent)> ChageAccountAsync(ChangeAccountDto changeAccount)
        {
            var student = await studentRepository.GetByIdAsync(changeAccount.UserId);

            if (student is not null)
            {
                student.BankAccout = changeAccount.BankAccount;

                await studentRepository.UpdateAsync(student);
                await studentRepository.SaveChangesAsync();

                return (true, student);
            }

            return (false, null);
        }

        public async Task<(bool isSuccessful, Mark mark)> AddSubjectAsync(AddSubjectDto addSubject)
        {
            var student = await studentRepository.GetByIdAsync(addSubject.StudentId);
            var subject = await subjectRepository.GetByIdAsync(addSubject.SubjectId);

            if (student is not null && subject is not null)
            {
                var mark = new Mark
                {
                    SubjectId = addSubject.SubjectId,
                    StudentId = addSubject?.StudentId,
                    PartialMark = 0,
                    ExamMark = 0,
                    TotalMark = 0
                };

                await markRepository.AddAsync(mark);
                await markRepository.SaveChangesAsync();

                return (true, mark);
            }

            return(false, null);
        }
    }
}
