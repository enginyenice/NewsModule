using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NewsModule.Business.Exceptions;
using NewsModule.Business.Interfaces;
using NewsModule.Business.Security;
using NewsModule.DataAccess.Repositories.Interfaces;
using NewsModule.DataAccess.UnitOfWorks;
using NewsModule.DTOs.UserDtos;
using NewsModule.Entities.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NewsModule.Business.Concreates
{
    public class UserManager : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IJWTHelper _jwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        public UserManager(IGenericRepository<User> userRepository, IUnitOfWork unitOfWork, IGenericRepository<Role> roleRepository, IJWTHelper jwtHelper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _roleRepository = roleRepository;
            _jwtHelper = jwtHelper;
        }

        public async Task<TokenDto> Login(LoginDto loginDto)
        {
            var user = await _userRepository.GetAsync(p => p.Email == loginDto.Email && p.Password == loginDto.Password);
            if (user == null) throw new BusinessException("Kullanıcı adı veya şifre hatalıdır");
            
            var userRole = _userRepository.Query().Where(p => p.Id == user.Id).Include(p => p.Roles).FirstOrDefault();
            return _jwtHelper.CreateJwtToken(userRole);
        }
        public async Task<TokenDto> Register(RegisterDto registerDto)
        {
            var findUser = await _userRepository.GetAsync(p => p.Email == registerDto.Email);
            if (findUser != null) throw new BusinessException("Bu email adresi zaten kayıtlıdır");

            User user = new User(registerDto.Email,registerDto.Password);
            
            
            var adminRole = _roleRepository.Query().FirstOrDefault(p => p.RoleName == "Admin");
            if(adminRole == null)
            {
                adminRole = new Role("Admin");
                _roleRepository.Add(adminRole);
            }
            user.Roles = new List<Role>
            {
                adminRole
            };
            _userRepository.Add(user);
            var result = await _unitOfWork.SaveChangesAsync();
            if (result == 0) throw new BusinessException("Bir hata oluştu");
            return _jwtHelper.CreateJwtToken(user);

        }
    }
}
