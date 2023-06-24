using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumidityData.DTO;
using HumidityData.Models;

namespace HumidityData.Interfaces.IService
{
    public interface IUserService
    {
        public Task<User> UserLogin(UserRequestDTO request);
        public Task<ResponseDTO> GenerateJWTToken(int userId);
    }
}
