using HumidityData.DTO;
using HumidityData.Interfaces.IService;
using HumidityData.Interfaces.IRepositories;
using HumidityData.Models;

namespace HumidityData.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {

            _userRepository = userRepository;
        }
        public async Task<User> UserLogin(UserRequestDTO request)
        {
            return await _userRepository.UserLogin(request);

        }
        public async Task<ResponseDTO> GenerateJWTToken(int userId)
        {

            return await _userRepository.GenerateJWTToken(userId);
        }
    }
}