using System.ComponentModel.DataAnnotations;

namespace HumidityData.DTO
{
    public class UserRequestDTO
    {
        [Required]
        public int userId { get; set; }
    }
}
