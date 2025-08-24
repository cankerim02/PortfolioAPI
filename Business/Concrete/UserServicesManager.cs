using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserServicesManager : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServicesManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> AddUserAsync(UserAddDto userDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(userDto.Email);
            if (existingUser != null)
                return false;

            var user = new User
            {
                Email = userDto.Email,
                Password = userDto.Password,
                Role = userDto.Role,
            };

            await _userRepository.AddAsync(user);
            return true;

        }
    }
}
