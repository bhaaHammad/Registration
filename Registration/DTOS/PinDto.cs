using System.ComponentModel.DataAnnotations;

namespace Registration.DTOS
{
    public class PinDto
    {
        public long UserId { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string Pin { get; set; } = null!;
    }
}
