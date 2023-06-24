using HumidityData.DTO;
using Microsoft.AspNetCore.Mvc;
using HumidityData.Interfaces.IService;

namespace HumidityData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class authorizationController : ControllerBase
    {
        private readonly IUserService _userServices;
        public authorizationController(IUserService userService)
        {
            _userServices = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserRequestDTO request)
        {
            ResponseDTO response = new ResponseDTO();
            var user = await _userServices.UserLogin(request);
            if (user.UserId == 0)
            {
                response.success = false;
                response.message = "user does not exist";
                return BadRequest(response);
            }
            var result =await  _userServices.GenerateJWTToken((int)user.UserId);
            if (result is null)
            {
                return BadRequest("Token generation failure");
            }
            return Ok(result);
        }
    }
}
