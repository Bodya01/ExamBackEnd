using Exam.Data.Entities;
using Exam.Data.Infrastructure;
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
        public StudentService(
            IRepository<Student> studentRepository
            )
        {
            this.studentRepository = studentRepository;
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

    }
}
