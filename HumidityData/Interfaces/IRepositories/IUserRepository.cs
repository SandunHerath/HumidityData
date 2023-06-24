using HumidityData.DTO;
using HumidityData.Models;

namespace HumidityData.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        public Task<User> UserLogin(UserRequestDTO request);
        public Task<ResponseDTO> GenerateJWTToken(int userId);
    }
}
