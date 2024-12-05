using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Entity
{
    [Table("PrivacyPolicies")]
    public class PrivacyPolicyEntity
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("UserEntity")]
        public long UserId { get; set; }
        public required UserEntity User { get; set; }

        public bool IsAccepted { get; set; }
        public DateTime AcceptedDate { get; set; }
    }
}
