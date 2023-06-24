namespace HumidityData.Interfaces.IService
{
    public interface IHumidityDataService
    {
        public Task<List<Models.HumidityData>> GetHumidityData(int buildingId, int floorId, int roomId);
    }
}
