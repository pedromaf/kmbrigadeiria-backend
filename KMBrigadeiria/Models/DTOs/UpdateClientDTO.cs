using KMBrigadeiria.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace KMBrigadeiria.Models.DTOs
{
    public class UpdateClientDTO
    {
        [ValidId]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
