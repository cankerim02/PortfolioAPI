using Business.Abstract;
using Core.Helper.Abstract;
using DataAccess.Abstract;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthServicesManager : IAuthServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHelper _jwtHelper;

        public AuthServicesManager(IUserRepository userRepository, IJwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
        }

        public async Task<LoginResultDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetByEmailAndPasswordAsync(loginDto.Email, loginDto.Password);

            if(user is null)
            {
                return new LoginResultDto { Success = false, Message = "Geçersiz kullanıcı bilgileri" };

            }

            var token = _jwtHelper.CreateToken(user);

            return new LoginResultDto
            {
                Success = true,
                Message = "Giriş Başarılı",
                Token = token
            };

        }
    }
}
