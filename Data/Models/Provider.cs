using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public List<Offer> Offers { get; set; } = [];
    }
}
