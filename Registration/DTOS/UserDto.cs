using System.ComponentModel.DataAnnotations;

namespace Registration.DTOS
{
    public class UserDto
    {
        public required string CustomerName { get; set; }
        [StringLength(100)]
        public required string IcNumber { get; set; }
        [Phone]
        public required string MobileNumber { get; set; }
        [EmailAddress]
        public required string EmailAddress { get; set; }
    }
}
