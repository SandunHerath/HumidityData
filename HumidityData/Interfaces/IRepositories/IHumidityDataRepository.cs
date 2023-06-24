namespace HumidityData.Interfaces.IRepositories
{
    public interface IHumidityDataRepository
    {
        public Task<List<Models.HumidityData>> GetHumidityData(int buildingId, int floorId, int roomId);
    }
}
