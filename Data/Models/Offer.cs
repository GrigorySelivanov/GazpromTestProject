using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }
        public required string Mark { get; set; }
        public required string Model { get; set; }
        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public required Provider Provider { get; set; }
        public required DateTimeOffset RegistrationDate { get; set; }
    }
}
