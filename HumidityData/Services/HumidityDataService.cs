using HumidityData.DTO;
using HumidityData.Interfaces.IRepositories;
using HumidityData.Interfaces.IService;
using Microsoft.EntityFrameworkCore;

namespace HumidityData.Services
{
    public class HumidityDataService : IHumidityDataService
    {
        private readonly IHumidityDataRepository _humidityDataRepository;
        public HumidityDataService(IHumidityDataRepository humidityDataRepository)
        {
            _humidityDataRepository = humidityDataRepository;
        }

        public async Task<List<Models.HumidityData>> GetHumidityData(int buildingId,int floorId, int roomId)
        {

            return await _humidityDataRepository.GetHumidityData(buildingId, floorId, roomId);
        }
    }
}
