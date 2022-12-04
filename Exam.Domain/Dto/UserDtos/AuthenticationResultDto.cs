using Exam.Data.Entities;
using System;

namespace Exam.Domain.Dto.UserDtos.Login
{
    public class AuthenticationResultDto
    {
        public string JwtId { get; set; }
        public string JwtToken { get; set; }
        public DateTime? JwtExpireTime { get; set; }
        public string RefreshToken { get; set; }
        public User User { get; set; }
    }
}
