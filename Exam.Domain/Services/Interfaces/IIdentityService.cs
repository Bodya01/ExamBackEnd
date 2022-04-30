using Exam.Domain.Dto.UserDtos.Login;
using Exam.Domain.Dto.UserDtos.Refresh;
using Exam.Domain.Dto.UserDtos.Registration;
using System.Threading.Tasks;

namespace Exam.Domain.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<(bool isSuccessful, AuthenticationResultDto authResult)> RegisterAsync(UserRegistrationDto registrationDto);
        Task<(bool isSuccessful, AuthenticationResultDto authResult)> LoginAsync(LoginDto loginDto);
        Task<(bool IsSuccessful, AuthenticationResultDto authResult)> RefreshAsync(RefreshTokenDto refreshTokenDto);
    }
}
