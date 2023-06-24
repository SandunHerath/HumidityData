using HumidityData.DTO;
using HumidityData.Interfaces.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumidityData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class humidityDataController : ControllerBase
    {
        private readonly IHumidityDataService _humidityDataService;
        public humidityDataController(IHumidityDataService humidityDataService)
        {
            _humidityDataService = humidityDataService;
        }

        [HttpGet("{buildingId}/{floorId}/{roomId}")]
        [Authorize]
        public async Task <IActionResult> GetHumidityData(int buildingId, int floorId, int roomId)
        {
            var humidityResponse = await _humidityDataService.GetHumidityData(buildingId, floorId, roomId);
            if (humidityResponse.Count==0)
            {
                return BadRequest("No data Availabe");
            }
            var data = humidityResponse.Select(x => new HumidityDataDTO(x)).ToList();
            HumidityResponseDTO response= new HumidityResponseDTO();
            response.buildingId=buildingId;
            response.floorId=floorId;
            response.roomId=roomId;
            response.data=data;
            return Ok(response);
        }
    }
}
