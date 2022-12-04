namespace Exam.Domain.Dto.UserDtos.Registration
{
    public class StudentRegistrationDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int GroupId { get; set; }
        public bool HasScholarship { get; set; } = false;
    }
}
