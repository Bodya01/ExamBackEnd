namespace Exam.Domain.Dto.UserDtos.Login
{
    public class AuthenticationResultDto
    {
        public string JwtToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
