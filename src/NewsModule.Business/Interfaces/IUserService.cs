using NewsModule.DTOs.UserDtos;

namespace NewsModule.Business.Interfaces
{
    public interface IUserService
    {
        Task<TokenDto> Login(LoginDto loginDto);
        Task<TokenDto> Register(RegisterDto registerDto);

    }
}
