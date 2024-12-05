using System.ComponentModel.DataAnnotations;

namespace Registration.DTOS
{
    public class LoginDto
    {
        [Required]
        public string IcNumber { get; set; } = null!;
    }
}
