namespace HumidityData.DTO
{
    public class HumidityResponseDTO
    {
        public int buildingId { get; set; }
        public int floorId { get; set; }
        public int roomId { get; set; }
        public List<HumidityDataDTO> data { get; set; }
    }
}
