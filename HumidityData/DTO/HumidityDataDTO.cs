namespace HumidityData.DTO
{
    public class HumidityDataDTO
    {
        public DateTime? timestamp { get; set; }
        public float? h { get; set; }
        public HumidityDataDTO (Models.HumidityData humidity)
        {
           timestamp = humidity.Timestamp;
           h = (float?)humidity.H;
        }
    }
}
