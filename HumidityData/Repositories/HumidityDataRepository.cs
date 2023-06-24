using HumidityData.DTO;
using HumidityData.Interfaces.IRepositories;
using HumidityData.Models;

namespace HumidityData.Repositories
{
    public class HumidityDataRepository : IHumidityDataRepository
    {
        private readonly HumidityDataContext _context;
       public HumidityDataRepository(HumidityDataContext context)
        {
            _context = context;

        }
        public async Task<List<Models.HumidityData>> GetHumidityData(int buildingId, int floorId, int roomId)
        {
            return _context.HumidityData.Where(x => x.BuildingId == buildingId && x.FloorId == floorId && x.RoomId == roomId).ToList();  

        }
    }
}


