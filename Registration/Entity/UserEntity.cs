using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Entity
{
    [Table("Users")]
    public class UserEntity
    {
        [Key]
        public long Id { get; set; }
        [StringLength(100)]
        public required string CustomerName { get; set; }
        public required string IcNumber { get; set; }
        [Phone]
        public required string MobileNumber { get; set; }
        [EmailAddress]
        public required string EmailAddress { get; set; }
        [StringLength(6, MinimumLength = 6)]
        public string? Pin { get; set; }
        public bool BiometricsEnabled { get; set; } = false;
        public string? BiometricsData { get; set; }
    }
}
