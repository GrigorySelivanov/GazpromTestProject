using System.ComponentModel.DataAnnotations;

namespace Data.DTOs.ProviderDTOs
{
    public class ProviderCreateDTO
    {
        [Required(ErrorMessage = "Добавьте наименование поставщика")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Добавьте дату создания")]
        public required DateTimeOffset CreatedDate { get; set; }
    }
}
