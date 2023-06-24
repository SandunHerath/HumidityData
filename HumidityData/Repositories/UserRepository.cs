using HumidityData.DTO;
using HumidityData.Interfaces.IRepositories;
using HumidityData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HumidityData.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HumidityDataContext _context;
        private readonly IConfiguration _appSettingsconfiguration;
        public UserRepository(HumidityDataContext context, IConfiguration appSettingsconfiguration)
        {
            _appSettingsconfiguration = appSettingsconfiguration;
            _context = context;
        }
        public async Task<User> UserLogin(UserRequestDTO request)
        {
            User nullUser = new User();
            nullUser.UserId = 0;
            var user = _context.Users.Where(u => u.UserId == request.userId).FirstOrDefault() == null ? nullUser : _context.Users.Where(u => u.UserId == request.userId).FirstOrDefault();
            return user;
        }
        public async Task<ResponseDTO> GenerateJWTToken(int userId)
        {

            ResponseDTO response = new ResponseDTO();
            var userjwtToken = CreateJwtToken(userId);
            response.success = true;
            response.message = "verified successfully";
            response.token = userjwtToken;
            return response;
        }
        private string CreateJwtToken(int userId)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim("UserId",userId.ToString() ),

            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _appSettingsconfiguration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds);
                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}
