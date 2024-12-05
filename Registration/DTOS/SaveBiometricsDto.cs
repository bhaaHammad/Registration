using System.ComponentModel.DataAnnotations;

namespace Registration.DTOS
{
    public class SaveBiometricsDto
    {
        public long UserId { get; set; }
        [Required]
        public string BiometricsData { get; set; } = null!;

    }
}
